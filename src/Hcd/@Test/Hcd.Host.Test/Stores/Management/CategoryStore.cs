using Hcd.Contract.Requests.Management.Categories;
using Esg.Shared.Test.Abstractions;

namespace Hcd.Host.Test.Stores.Management;

public record CategoryStore(HttpClient HttpClient) : IEntityStore<Guid, CategoryGetDetailResponse>
{
    private const string Endpoint = "/api/v1/categories";

    public async Task<CategoryGetDetailResponse> GetOne(Guid id)
    {
        var response = await HttpClient.GetAsync($"{Endpoint}/{id}");
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadFromJsonAsync<CategoryGetDetailResponse>();
        return responseContent!;
    }
}