using Hcd.Contract.Requests.Management.Tags;
using Esg.Shared.Test.Abstractions;

namespace Hcd.Host.Test.Stores.Management;

public record TagStore(HttpClient HttpClient) : IEntityStore<Guid, TagGetDetailResponse>
{
    private const string Endpoint = "/api/v1/tags";

    public async Task<TagGetDetailResponse> GetOne(Guid id)
    {
        var response = await HttpClient.GetAsync($"{Endpoint}/{id}");
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadFromJsonAsync<TagGetDetailResponse>();
        return responseContent!;
    }
}