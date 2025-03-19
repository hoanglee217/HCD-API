using Hcd.Contract.Requests.Management.Categories;
using Hcd.Host.Test.Setup;
using Hcd.Host.Test.Stores.Management;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.Categories;

public class CategoryCreateTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/categories";

    [Fact]
    public async Task ShouldCreateCorrectly()
    {
        var request = new CategoryCreateRequest()
        {
            // TODO: Add the request properties
            Name = throw new System.NotImplementedException(),
        };

        var createResponse = await AuthenticatedClient.PostAsJsonAsync(_endpoint, request);
        createResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.Created, createResponse.StatusCode);
        
        // Response data should not be null
        var createResponseData = await createResponse.Content.ReadFromJsonAsync<CategoryCreateResponse>();
        Assert.NotNull(createResponseData);

        // Check if created
        var store = new CategoryStore(AuthenticatedClient);
        var category = await store.GetOne(createResponseData.Id);
        Assert.Equal(request.Name, category.Name);
    }
}