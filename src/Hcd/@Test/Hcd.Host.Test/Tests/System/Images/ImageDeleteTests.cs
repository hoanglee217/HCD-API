using Hcd.Host.Test.Factories;
using Hcd.Host.Test.Factories.System;
using Hcd.Host.Test.Setup;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.System.Images;

public class ImageDeleteTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/images";

    [Fact]
    public async Task ShouldDeleteCorrectly()
    {
        var factory = new ImageFactory(AuthenticatedClient);
        var newImage = await factory.Create();

        var deleteResponse = await AuthenticatedClient.DeleteAsync($"{_endpoint}/{newImage.Id}");
        deleteResponse.EnsureSuccessStatusCode();

        // Check status code
        Assert.Equal(System.Net.HttpStatusCode.OK, deleteResponse.StatusCode);

        // Check if deleted
        var getOneResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/{newImage.Id}");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, getOneResponse.StatusCode);
    }
}