using Hcd.Host.Test.Factories;
using Hcd.Host.Test.Factories.Management;
using Hcd.Host.Test.Setup;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.Categories;

public class CategoryDeleteTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/categories";

    [Fact]
    public async Task ShouldDeleteCorrectly()
    {
        var factory = new CategoryFactory(AuthenticatedClient);
        var newCategory = await factory.Create();

        var deleteResponse = await AuthenticatedClient.DeleteAsync($"{_endpoint}/{newCategory.Id}");
        deleteResponse.EnsureSuccessStatusCode();

        // Check status code
        Assert.Equal(System.Net.HttpStatusCode.OK, deleteResponse.StatusCode);

        // Check if deleted
        var getOneResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/{newCategory.Id}");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, getOneResponse.StatusCode);
    }
}