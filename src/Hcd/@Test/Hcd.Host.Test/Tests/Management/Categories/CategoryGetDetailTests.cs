using Hcd.Contract.Requests.Management.Categories;
using Hcd.Host.Test.Factories.Management;
using Hcd.Host.Test.Setup;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.Categories;

public class CategoryGetDetailTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/categories";

    [Fact]
    public async Task ShouldGetDetailCorrectly()
    {
        var factory = new CategoryFactory(AuthenticatedClient);
        var newCategory = await factory.Create();

        var getAllResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/{newCategory.Id}");
        getAllResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, getAllResponse.StatusCode);

        var category = await getAllResponse.Content.ReadFromJsonAsync<CategoryGetDetailResponse>();
        Assert.NotNull(category);
        Assert.Equal(newCategory.Id, category.Id);
    }

    [Fact]
    public async Task ShouldReturnNotFound()
    {
        var getAllResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/00000000-0000-0000-0000-000000000000");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, getAllResponse.StatusCode);
    }
}