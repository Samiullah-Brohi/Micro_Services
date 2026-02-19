using System.Data;
using Microsoft.EntityFrameworkCore;
using supportservices.Data;
using supportservices.Models;

namespace supportservices.Services;

public class SupportServicesDataService : ISupportServicesDataService
{
    private readonly SupportDbContext _dbContext;
    private readonly string _employeeSupportQuery;

    public SupportServicesDataService(SupportDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _employeeSupportQuery = configuration["QuerySettings:EmployeeSupportQuery"]
            ?? throw new InvalidOperationException("QuerySettings:EmployeeSupportQuery is missing.");
    }

    public async Task<IReadOnlyList<SupportServiceRecord>> GetEmployeeSupportDataAsync(
        DateTime startDate,
        DateTime endDate,
        int employeeId,
        CancellationToken cancellationToken)
    {
        var results = new List<SupportServiceRecord>();

        await using var connection = _dbContext.Database.GetDbConnection();
        await using var command = connection.CreateCommand();

        command.CommandText = _employeeSupportQuery;
        command.CommandType = CommandType.Text;

        AddParameter(command, "@StartDate", startDate);
        AddParameter(command, "@EndDate", endDate);
        AddParameter(command, "@EmployeeID", employeeId);

        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync(cancellationToken);
        }

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            results.Add(new SupportServiceRecord
            {
                FirstLogin = ReadNullableDateTime(reader, "1stlogin"),
                SecondLogin = ReadNullableDateTime(reader, "2ndlogin"),
                FirstSwipe = ReadNullableDateTime(reader, "1stswipe"),
                SecondSwipe = ReadNullableDateTime(reader, "2ndswipe")
            });
        }

        return results;
    }

    private static void AddParameter(IDbCommand command, string name, object value)
    {
        var parameter = command.CreateParameter();
        parameter.ParameterName = name;
        parameter.Value = value;
        command.Parameters.Add(parameter);
    }

    private static DateTime? ReadNullableDateTime(IDataRecord record, string columnName)
    {
        var ordinal = record.GetOrdinal(columnName);
        return record.IsDBNull(ordinal) ? null : record.GetDateTime(ordinal);
    }
}
