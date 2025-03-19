using Hcd.Contract.Requests.System.Images;
using Hcd.Host.Test.Factories.System;
using Hcd.Host.Test.Setup;
using Hcd.Host.Test.Stores.System;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.System.Images;

public class ImageUpdateTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/images";

    [Fact]
    public async Task ShouldUpdateCorrectly()
    {
        var factory = new ImageFactory(AuthenticatedClient);
        var newImage = await factory.Create();

        var request = new ImageUpdateRequest()
        {
            Id = newImage.Id,
            // TODO: Update the request properties
            Name = throw new System.NotImplementedException()
        };

        var updateResponse = await AuthenticatedClient.PatchAsJsonAsync($"{_endpoint}/{request.Id}", request);
        updateResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, updateResponse.StatusCode);

        var store = new ImageStore(AuthenticatedClient);
        var updatedImage = await store.GetOne(request.Id);
        Assert.Equal(request.Name, updatedImage.Name);
    }
}