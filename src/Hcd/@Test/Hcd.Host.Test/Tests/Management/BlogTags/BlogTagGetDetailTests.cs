using Hcd.Contract.Requests.Management.BlogTags;
using Hcd.Host.Test.Factories.Management;
using Hcd.Host.Test.Setup;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.BlogTags;

public class BlogTagGetDetailTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/blog-tags";

    [Fact]
    public async Task ShouldGetDetailCorrectly()
    {
        var factory = new BlogTagFactory(AuthenticatedClient);
        var newBlogTag = await factory.Create();

        var getAllResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/{newBlogTag.Id}");
        getAllResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, getAllResponse.StatusCode);

        var blogTag = await getAllResponse.Content.ReadFromJsonAsync<BlogTagGetDetailResponse>();
        Assert.NotNull(blogTag);
        Assert.Equal(newBlogTag.Id, blogTag.Id);
    }

    [Fact]
    public async Task ShouldReturnNotFound()
    {
        var getAllResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/00000000-0000-0000-0000-000000000000");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, getAllResponse.StatusCode);
    }
}