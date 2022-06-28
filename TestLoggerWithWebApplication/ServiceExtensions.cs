using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using TestLogger4AppInsight;

namespace TestLoggerWithWebApplication
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomLogger(this IServiceCollection services, IConfiguration configuration)
        {
            var option = new ApplicationInsightsServiceOptions
            {
                InstrumentationKey = configuration.GetValue<string>("Telemetry:InstrumentationKey"),
                EnableAdaptiveSampling = false,
                EnableAppServicesHeartbeatTelemetryModule = true,
                EnablePerformanceCounterCollectionModule = true,
                EnableRequestTrackingTelemetryModule = true,
                EnableDependencyTrackingTelemetryModule = true,
            };

            services.AddApplicationInsightsTelemetry(option);
           
            return services.AddScoped<ICustomLogger, CustomAiLogger>();
        }
    }
}
