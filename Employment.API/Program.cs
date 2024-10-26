using Employment.API.Configurations;
using Employment.API.Extensions;
using Employment.API.Middleware;
using Employment.API.OptionsSetup;
using Employment.Application;
using Employment.Infrastructure;
using Employment.Infrastructure.BackgroundJobs;
using Employment.Infrastructure.Seeders;
using Employment.Persistence;
using FluentValidation;
using Hangfire;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilogConfig();

builder.Services.AddMediatR(
    cfg => cfg.RegisterServicesFromAssembly(Employment.Application.AssemblyReference.Assembly));

builder.Services.AddValidatorsFromAssembly(
    Employment.Application.AssemblyReference.Assembly,
    includeInternalTypes: true);

builder.Services.AddAppServicesDIConfig();
builder.Services.AddPersistenceStrapping();
builder.Services.AddInfrastructureStrapping();
builder.Services.AddApplicationStrapping();

builder.Services.AddMapsterConfig();

builder.Services.AddDbConfig(builder.Configuration);
builder.Services.AddIdentityConfig(builder.Configuration);
await builder.Services.AddDBSeederExtension();

builder.Services.AddHangfireConfig(builder.Configuration);

builder.Services.AddRedisConfig(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandlerMiddleware>();

builder.Services.ConfigureOptions<JwtOptionsSetup>();

builder
    .Services
    .AddControllers()
    .AddApplicationPart(Employment.Presentation.AssemblyReference.Assembly)
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocumentation();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHsts();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseHangfireDashboard("/HangFireDashboard");

RecurringJob.AddOrUpdate<VacancyArchiverJob>(
                    "ArchiveExpiredOrMaxApplicationsVacancies",
                    job => job.ArchiveExpiredOrMaxApplicationsVacancies(),
                    Cron.Minutely);

app.MapControllers();

app.Run();