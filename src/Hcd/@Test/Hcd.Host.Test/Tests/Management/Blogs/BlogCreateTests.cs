using Hcd.Contract.Requests.Management.Blogs;
using Hcd.Host.Test.Setup;
using Hcd.Host.Test.Stores.Management;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.Blogs;

public class BlogCreateTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/blogs";

    [Fact]
    public async Task ShouldCreateCorrectly()
    {
        var request = new BlogCreateRequest()
        {
            // TODO: Add the request properties
            Name = throw new System.NotImplementedException(),
        };

        var createResponse = await AuthenticatedClient.PostAsJsonAsync(_endpoint, request);
        createResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.Created, createResponse.StatusCode);
        
        // Response data should not be null
        var createResponseData = await createResponse.Content.ReadFromJsonAsync<BlogCreateResponse>();
        Assert.NotNull(createResponseData);

        // Check if created
        var store = new BlogStore(AuthenticatedClient);
        var blog = await store.GetOne(createResponseData.Id);
        Assert.Equal(request.Name, blog.Name);
    }
}