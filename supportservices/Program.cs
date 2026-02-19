using Microsoft.EntityFrameworkCore;
using supportservices.Data;
using supportservices.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("SupportDb")
    ?? throw new InvalidOperationException("Connection string 'SupportDb' is missing.");

builder.Services.AddDbContext<SupportDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<ISupportServicesDataService, SupportServicesDataService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
