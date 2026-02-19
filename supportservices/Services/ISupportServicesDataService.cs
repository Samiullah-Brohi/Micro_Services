using supportservices.Models;

namespace supportservices.Services;

public interface ISupportServicesDataService
{
    Task<IReadOnlyList<SupportServiceRecord>> GetEmployeeSupportDataAsync(
        DateTime startDate,
        DateTime endDate,
        int employeeId,
        CancellationToken cancellationToken);
}
