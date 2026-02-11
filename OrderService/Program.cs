var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

var productBaseUrl = builder.Configuration["PRODUCT_SERVICE_URL"]  ?? "http://localhost:5001/swagger/index.html";  // or direct for local non-Docker runs

builder.Services.AddHttpClient("ProductClient", client =>
{
    client.BaseAddress = new Uri(productBaseUrl);
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
