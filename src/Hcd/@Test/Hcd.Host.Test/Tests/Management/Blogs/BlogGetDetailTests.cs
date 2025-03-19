using Hcd.Contract.Requests.Management.Blogs;
using Hcd.Host.Test.Factories.Management;
using Hcd.Host.Test.Setup;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.Blogs;

public class BlogGetDetailTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/blogs";

    [Fact]
    public async Task ShouldGetDetailCorrectly()
    {
        var factory = new BlogFactory(AuthenticatedClient);
        var newBlog = await factory.Create();

        var getAllResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/{newBlog.Id}");
        getAllResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, getAllResponse.StatusCode);

        var blog = await getAllResponse.Content.ReadFromJsonAsync<BlogGetDetailResponse>();
        Assert.NotNull(blog);
        Assert.Equal(newBlog.Id, blog.Id);
    }

    [Fact]
    public async Task ShouldReturnNotFound()
    {
        var getAllResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/00000000-0000-0000-0000-000000000000");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, getAllResponse.StatusCode);
    }
}