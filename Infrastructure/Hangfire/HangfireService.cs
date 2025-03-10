using Application.Common.Interfaces;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Hangfire;

public static class HangfireService
{
    public static void SetupHangfire(this IServiceCollection services, IConfiguration configuration,
         IWebHostEnvironment env)
    {
        services.AddScoped<IScheduledJobService, ScheduledJobService>();
        services.AddHangfire(config => config.UseSqlServerStorage(configuration.GetConnectionString("DotVueDb"),
                new SqlServerStorageOptions()
                {
                    QueuePollInterval = TimeSpan.FromMinutes(5), PrepareSchemaIfNecessary = true,
                }
            )
        );

        services.AddHangfireServer();
    }

    public static void UseHangfire(this IApplicationBuilder app, IConfiguration configuration, IWebHostEnvironment env)
    {
        
        app.UseHangfireDashboard("/hangfire" /*,
            new DashboardOptions { Authorization = new[] { new HangfireAuthorizationFilter(configuration) }}*/);
        
        RecurringJob.AddOrUpdate<IScheduledJobService>("CalculateSum",
            x => x.ScheduledCalculateSum(), Cron.Minutely);
    }
}
