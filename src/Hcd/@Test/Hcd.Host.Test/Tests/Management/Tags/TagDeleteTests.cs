using Hcd.Host.Test.Factories;
using Hcd.Host.Test.Factories.Management;
using Hcd.Host.Test.Setup;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.Tags;

public class TagDeleteTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/tags";

    [Fact]
    public async Task ShouldDeleteCorrectly()
    {
        var factory = new TagFactory(AuthenticatedClient);
        var newTag = await factory.Create();

        var deleteResponse = await AuthenticatedClient.DeleteAsync($"{_endpoint}/{newTag.Id}");
        deleteResponse.EnsureSuccessStatusCode();

        // Check status code
        Assert.Equal(System.Net.HttpStatusCode.OK, deleteResponse.StatusCode);

        // Check if deleted
        var getOneResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/{newTag.Id}");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, getOneResponse.StatusCode);
    }
}