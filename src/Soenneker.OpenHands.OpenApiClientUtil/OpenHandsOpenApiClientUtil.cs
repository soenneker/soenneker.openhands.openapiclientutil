using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.OpenHands.HttpClients.Abstract;
using Soenneker.OpenHands.OpenApiClient;
using Soenneker.OpenHands.OpenApiClientUtil.Abstract;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.OpenHands.OpenApiClientUtil;

/// <inheritdoc cref="IOpenHandsOpenApiClientUtil" />
public sealed class OpenHandsOpenApiClientUtil : IOpenHandsOpenApiClientUtil
{
    private readonly AsyncSingleton<OpenHandsOpenApiClient> _client;

    public OpenHandsOpenApiClientUtil(IOpenHandsOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<OpenHandsOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            if (httpClient.BaseAddress is not null)
                requestAdapter.BaseUrl = httpClient.BaseAddress.ToString().TrimEnd('/');

            return new OpenHandsOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<OpenHandsOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
