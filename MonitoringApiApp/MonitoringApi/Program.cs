using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using MonitoringApi.HealthChecks;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks()
    .AddCheck<RandomHealthCheck>("Site health check")
    .AddCheck<RandomHealthCheck>("Database Health check");
builder.Services.AddWatchDogServices();

builder.Services.AddHealthChecksUI(opts =>
    {
        opts.AddHealthCheckEndpoint("api", "/health");
        opts.SetEvaluationTimeInSeconds(5);
        opts.SetMinimumSecondsBetweenFailureNotifications(10);

    }).AddInMemoryStorage();

var app = builder.Build();

app.UseWatchDogExceptionLogger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecksUI();

app.UseWatchDog(opts =>
{
    opts.WatchPageUsername = app.Configuration.GetValue<string>("Watchdog:UserName");
    opts.WatchPagePassword = app.Configuration.GetValue<string>("Watchdog:Password"); ;
});
app.Run();
