using Hcd.Contract.Requests.Management.Categories;
using Hcd.Host.Test.Factories.Management;
using Hcd.Host.Test.Setup;
using Hcd.Host.Test.Stores.Management;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.Categories;

public class CategoryUpdateTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/categories";

    [Fact]
    public async Task ShouldUpdateCorrectly()
    {
        var factory = new CategoryFactory(AuthenticatedClient);
        var newCategory = await factory.Create();

        var request = new CategoryUpdateRequest()
        {
            Id = newCategory.Id,
            // TODO: Update the request properties
            Name = throw new System.NotImplementedException()
        };

        var updateResponse = await AuthenticatedClient.PatchAsJsonAsync($"{_endpoint}/{request.Id}", request);
        updateResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, updateResponse.StatusCode);

        var store = new CategoryStore(AuthenticatedClient);
        var updatedCategory = await store.GetOne(request.Id);
        Assert.Equal(request.Name, updatedCategory.Name);
    }
}