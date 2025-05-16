using Hcd.Contract.Requests.Management.BlogTags;
using Hcd.Host.Test.Factories.Management;
using Hcd.Host.Test.Setup;
using Hcd.Host.Test.Stores.Management;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.BlogTags;

public class BlogTagUpdateTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/blog-tags";

    [Fact]
    public async Task ShouldUpdateCorrectly()
    {
        var factory = new BlogTagFactory(AuthenticatedClient);
        var newBlogTag = await factory.Create();

        var request = new BlogTagUpdateRequest()
        {
            Id = newBlogTag.Id,
            // TODO: Update the request properties
            Name = throw new System.NotImplementedException()
        };

        var updateResponse = await AuthenticatedClient.PatchAsJsonAsync($"{_endpoint}/{request.Id}", request);
        updateResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, updateResponse.StatusCode);

        var store = new BlogTagStore(AuthenticatedClient);
        var updatedBlogTag = await store.GetOne(request.Id);
        Assert.Equal(request.Name, updatedBlogTag.Name);
    }
}