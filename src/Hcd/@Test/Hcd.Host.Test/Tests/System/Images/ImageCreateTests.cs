using Hcd.Contract.Requests.System.Images;
using Hcd.Host.Test.Setup;
using Hcd.Host.Test.Stores.System;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.System.Images;

public class ImageCreateTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/images";

    [Fact]
    public async Task ShouldCreateCorrectly()
    {
        var request = new ImageCreateRequest()
        {
            // TODO: Add the request properties
            Name = throw new System.NotImplementedException(),
        };

        var createResponse = await AuthenticatedClient.PostAsJsonAsync(_endpoint, request);
        createResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.Created, createResponse.StatusCode);
        
        // Response data should not be null
        var createResponseData = await createResponse.Content.ReadFromJsonAsync<ImageCreateResponse>();
        Assert.NotNull(createResponseData);

        // Check if created
        var store = new ImageStore(AuthenticatedClient);
        var image = await store.GetOne(createResponseData.Id);
        Assert.Equal(request.Name, image.Name);
    }
}