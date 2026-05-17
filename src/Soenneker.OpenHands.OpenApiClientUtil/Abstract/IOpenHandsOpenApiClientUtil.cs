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
    ValueTask<OpenHandsOpenApiClient> Get(CancellationToken cancellationToken = default);
}
