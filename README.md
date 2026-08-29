[![](https://img.shields.io/nuget/v/soenneker.openhands.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openhands.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openhands.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.openhands.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.openhands.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openhands.openapiclientutil/)

# Soenneker.OpenHands.OpenApiClientUtil

Exposes a cached OpenAPI client instance.

## Install

```bash
dotnet add package Soenneker.OpenHands.OpenApiClientUtil
```

## Quick start

```csharp
using Soenneker.OpenHands.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddOpenHandsOpenApiClientUtilAsSingleton();
```

Adds `OpenHandsOpenApiClientUtil` as a singleton service.

## What you get

- `IOpenHandsOpenApiClientUtil` — Exposes a cached OpenAPI client instance.
- `OpenHandsOpenApiClientUtilRegistrar` — Registers the OpenAPI client utility for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `OpenHandsOpenApiClientUtilRegistrar.AddOpenHandsOpenApiClientUtilAsSingleton(services)` | Adds `OpenHandsOpenApiClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `OpenHandsOpenApiClientUtilRegistrar.AddOpenHandsOpenApiClientUtilAsScoped(services)` | Adds `OpenHandsOpenApiClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
