using Soenneker.OpenHands.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.OpenHands.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class OpenHandsOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IOpenHandsOpenApiClientUtil _openapiclientutil;

    public OpenHandsOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IOpenHandsOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
