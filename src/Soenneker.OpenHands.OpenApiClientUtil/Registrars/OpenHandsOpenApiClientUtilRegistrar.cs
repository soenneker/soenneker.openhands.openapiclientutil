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
    public static IServiceCollection AddOpenHandsOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddOpenHandsOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IOpenHandsOpenApiClientUtil, OpenHandsOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="OpenHandsOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddOpenHandsOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddOpenHandsOpenApiHttpClientAsSingleton()
                .TryAddScoped<IOpenHandsOpenApiClientUtil, OpenHandsOpenApiClientUtil>();

        return services;
    }
}
