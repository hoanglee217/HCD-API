using Hcd.Contract.Requests.Management.BlogTags;
using Esg.Shared.Test.Abstractions;

namespace Hcd.Host.Test.Stores.Management;

public record BlogTagStore(HttpClient HttpClient) : IEntityStore<Guid, BlogTagGetDetailResponse>
{
    private const string Endpoint = "/api/v1/blog-tags";

    public async Task<BlogTagGetDetailResponse> GetOne(Guid id)
    {
        var response = await HttpClient.GetAsync($"{Endpoint}/{id}");
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadFromJsonAsync<BlogTagGetDetailResponse>();
        return responseContent!;
    }
}