using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SciChartBlazor.Services;

namespace SciChartBlazor;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds IKeyInterceptor as a Transient instance.
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    /// <returns>Continues the IServiceCollection chain.</returns>
    public static IServiceCollection AddSciChart(this IServiceCollection services, Action<SciChartOptions> options)
    {
        services.Configure(options);
        services.TryAddScoped<ISciChartBlazorService, SciChartBlazorService>();
        return services;
    }
}