using Hcd.Contract.Requests.Management.Tags;
using Hcd.Host.Test.Factories.Management;
using Hcd.Host.Test.Setup;
using Hcd.Host.Test.Stores.Management;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.Tags;

public class TagUpdateTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/tags";

    [Fact]
    public async Task ShouldUpdateCorrectly()
    {
        var factory = new TagFactory(AuthenticatedClient);
        var newTag = await factory.Create();

        var request = new TagUpdateRequest()
        {
            Id = newTag.Id,
            // TODO: Update the request properties
            Name = throw new System.NotImplementedException()
        };

        var updateResponse = await AuthenticatedClient.PatchAsJsonAsync($"{_endpoint}/{request.Id}", request);
        updateResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, updateResponse.StatusCode);

        var store = new TagStore(AuthenticatedClient);
        var updatedTag = await store.GetOne(request.Id);
        Assert.Equal(request.Name, updatedTag.Name);
    }
}