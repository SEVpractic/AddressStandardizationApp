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

builder.Services.GetServicesConfig();
builder.Services.GetSwaggerConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseDirectoryBrowser();

app.UseAuthorization();


app.MapControllers();

app.Run();