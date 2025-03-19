using Hcd.Contract.Requests.System.Images;
using Hcd.Host.Test.Factories.System;
using Hcd.Host.Test.Setup;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.System.Images;

public class ImageGetDetailTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/images";

    [Fact]
    public async Task ShouldGetDetailCorrectly()
    {
        var factory = new ImageFactory(AuthenticatedClient);
        var newImage = await factory.Create();

        var getAllResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/{newImage.Id}");
        getAllResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, getAllResponse.StatusCode);

        var image = await getAllResponse.Content.ReadFromJsonAsync<ImageGetDetailResponse>();
        Assert.NotNull(image);
        Assert.Equal(newImage.Id, image.Id);
    }

    [Fact]
    public async Task ShouldReturnNotFound()
    {
        var getAllResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/00000000-0000-0000-0000-000000000000");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, getAllResponse.StatusCode);
    }
}