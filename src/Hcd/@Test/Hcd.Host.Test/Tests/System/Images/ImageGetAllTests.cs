using Hcd.Contract.Requests.System.Images;
using Hcd.Host.Test.Factories.System;
using Hcd.Host.Test.Setup;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.System.Images;

public class ImageGetAllTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/images";

    [Fact]
    public async Task ShouldGetAllCorrectly()
    {
        var factory = new ImageFactory(AuthenticatedClient);
        await factory.Create();

        var getAllResponse = await AuthenticatedClient.GetAsync(_endpoint);
        getAllResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, getAllResponse.StatusCode);

        var getAllResponseData = await getAllResponse.Content.ReadFromJsonAsync<ImageGetAllResponse>();
        Assert.NotNull(getAllResponseData);
        Assert.Single(getAllResponseData.Items);
    }
}