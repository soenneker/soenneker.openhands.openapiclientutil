using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.OpenHands.HttpClients.Registrars;
using Soenneker.OpenHands.OpenApiClientUtil.Abstract;

namespace Soenneker.OpenHands.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class OpenHandsOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="OpenHandsOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddOpenHandsOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddOpenHandsOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IOpenHandsOpenApiClientUtil, OpenHandsOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="OpenHandsOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddOpenHandsOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddOpenHandsOpenApiHttpClientAsSingleton()
                .TryAddScoped<IOpenHandsOpenApiClientUtil, OpenHandsOpenApiClientUtil>();

        return services;
    }
}
