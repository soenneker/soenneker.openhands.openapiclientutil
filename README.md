[![](https://img.shields.io/nuget/v/soenneker.openhands.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openhands.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openhands.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.openhands.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.openhands.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openhands.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openhands.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.openhands.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.OpenHands.OpenApiClientUtil

Provides a configured OpenHands Cloud API client and reuses it for the lifetime of the registered service.

## Install

```bash
dotnet add package Soenneker.OpenHands.OpenApiClientUtil
```

## Configuration

```json
{
  "OpenHands": {
    "ApiKey": "your-api-key"
  }
}
```

## Usage

```csharp
using Soenneker.OpenHands.OpenApiClientUtil.Abstract;
using Soenneker.OpenHands.OpenApiClientUtil.Registrars;

services.AddOpenHandsOpenApiClientUtilAsSingleton();

IOpenHandsOpenApiClientUtil openHands = serviceProvider
    .GetRequiredService<IOpenHandsOpenApiClientUtil>();

var client = await openHands.Get(cancellationToken);
var conversations = await client.Api.V1.AppConversations.Search.GetAsync(request =>
{
    request.QueryParameters.Limit = 20;
}, cancellationToken);
```

Use `AddOpenHandsOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The underlying authenticated HTTP provider remains shared and is disposed by the service container at shutdown.
