using Hcd.Contract.Requests.Management.BlogTags;
using Hcd.Host.Test.Factories.Management;
using Hcd.Host.Test.Setup;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.BlogTags;

public class BlogTagGetAllTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/blog-tags";

    [Fact]
    public async Task ShouldGetAllCorrectly()
    {
        var factory = new BlogTagFactory(AuthenticatedClient);
        await factory.Create();

        var getAllResponse = await AuthenticatedClient.GetAsync(_endpoint);
        getAllResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, getAllResponse.StatusCode);

        var getAllResponseData = await getAllResponse.Content.ReadFromJsonAsync<BlogTagGetAllResponse>();
        Assert.NotNull(getAllResponseData);
        Assert.Single(getAllResponseData.Items);
    }
}