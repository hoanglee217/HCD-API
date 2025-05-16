using Hcd.Contract.Requests.Management.BlogTags;
using Hcd.Host.Test.Setup;
using Hcd.Host.Test.Stores.Management;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.BlogTags;

public class BlogTagCreateTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/blog-tags";

    [Fact]
    public async Task ShouldCreateCorrectly()
    {
        var request = new BlogTagCreateRequest()
        {
            // TODO: Add the request properties
            Name = throw new System.NotImplementedException(),
        };

        var createResponse = await AuthenticatedClient.PostAsJsonAsync(_endpoint, request);
        createResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.Created, createResponse.StatusCode);
        
        // Response data should not be null
        var createResponseData = await createResponse.Content.ReadFromJsonAsync<BlogTagCreateResponse>();
        Assert.NotNull(createResponseData);

        // Check if created
        var store = new BlogTagStore(AuthenticatedClient);
        var blogTag = await store.GetOne(createResponseData.Id);
        Assert.Equal(request.Name, blogTag.Name);
    }
}