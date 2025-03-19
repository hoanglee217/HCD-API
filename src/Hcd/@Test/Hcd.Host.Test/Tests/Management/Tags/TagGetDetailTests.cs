using Hcd.Contract.Requests.Management.Tags;
using Hcd.Host.Test.Factories.Management;
using Hcd.Host.Test.Setup;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.Tags;

public class TagGetDetailTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/tags";

    [Fact]
    public async Task ShouldGetDetailCorrectly()
    {
        var factory = new TagFactory(AuthenticatedClient);
        var newTag = await factory.Create();

        var getAllResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/{newTag.Id}");
        getAllResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, getAllResponse.StatusCode);

        var tag = await getAllResponse.Content.ReadFromJsonAsync<TagGetDetailResponse>();
        Assert.NotNull(tag);
        Assert.Equal(newTag.Id, tag.Id);
    }

    [Fact]
    public async Task ShouldReturnNotFound()
    {
        var getAllResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/00000000-0000-0000-0000-000000000000");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, getAllResponse.StatusCode);
    }
}