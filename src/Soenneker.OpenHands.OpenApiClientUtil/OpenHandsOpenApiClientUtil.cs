using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.OpenHands.HttpClients.Abstract;
using Soenneker.OpenHands.OpenApiClientUtil.Abstract;
using Soenneker.OpenHands.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.OpenHands.OpenApiClientUtil;

///<inheritdoc cref="IOpenHandsOpenApiClientUtil"/>
public sealed class OpenHandsOpenApiClientUtil : IOpenHandsOpenApiClientUtil
{
    private readonly AsyncSingleton<OpenHandsOpenApiClient> _client;

    public OpenHandsOpenApiClientUtil(IOpenHandsOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<OpenHandsOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("OpenHands:ApiKey");
            string authHeaderValueTemplate = configuration["OpenHands:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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