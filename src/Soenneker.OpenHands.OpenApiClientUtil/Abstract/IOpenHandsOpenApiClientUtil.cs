using Soenneker.OpenHands.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.OpenHands.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached OpenHands Cloud API client backed by the configured HTTP provider.
/// </summary>
public interface IOpenHandsOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached OpenHands client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The configured OpenHands client.</returns>
    ValueTask<OpenHandsOpenApiClient> Get(CancellationToken cancellationToken = default);
}
