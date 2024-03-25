using AddressStandardizationAPI.Configs;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/AddressStandardizationAPI.txt", rollingInterval: RollingInterval.Month)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

SD.ConfigureSD(builder.Configuration);

// Add services to the container.
builder.Host.UseSerilog();
builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.GetServicesConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapControllers();

app.Run();