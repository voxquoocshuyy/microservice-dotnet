using Common.Logging;
using Product.API.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Information("Starting Product API up...");

try
{
    // Add Serilog to the logging pipeline
    builder.Host.UseSerilog(Serilogger.Configuration);
    // Add configuration to the container.
    builder.Host.AddAppConfiguration();
    // Add services to the container.
    builder.Services.AddInfrastructure(builder.Configuration);

    var app = builder.Build();
    // Configure the HTTP request pipeline.
    app.UseInfrastructure();
    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Unhandled exception!");
}
finally
{
    Log.Information("Product API shutting down...");
    Log.CloseAndFlush();
}