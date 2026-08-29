using Soenneker.OpenHands.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.OpenHands.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IOpenHandsOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured open Hands OpenAPI Client used by the Open Hands OpenAPI Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested open Hands OpenAPI Client.</returns>
    ValueTask<OpenHandsOpenApiClient> Get(CancellationToken cancellationToken = default);
}
