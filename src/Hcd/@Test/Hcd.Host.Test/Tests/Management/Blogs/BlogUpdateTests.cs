using Hcd.Contract.Requests.Management.Blogs;
using Hcd.Host.Test.Factories.Management;
using Hcd.Host.Test.Setup;
using Hcd.Host.Test.Stores.Management;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.Blogs;

public class BlogUpdateTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/blogs";

    [Fact]
    public async Task ShouldUpdateCorrectly()
    {
        var factory = new BlogFactory(AuthenticatedClient);
        var newBlog = await factory.Create();

        var request = new BlogUpdateRequest()
        {
            Id = newBlog.Id,
            // TODO: Update the request properties
            Name = throw new System.NotImplementedException()
        };

        var updateResponse = await AuthenticatedClient.PatchAsJsonAsync($"{_endpoint}/{request.Id}", request);
        updateResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, updateResponse.StatusCode);

        var store = new BlogStore(AuthenticatedClient);
        var updatedBlog = await store.GetOne(request.Id);
        Assert.Equal(request.Name, updatedBlog.Name);
    }
}