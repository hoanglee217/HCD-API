using Hcd.Contract.Requests.Management.Blogs;
using Esg.Shared.Test.Abstractions;

namespace Hcd.Host.Test.Stores.Management;

public record BlogStore(HttpClient HttpClient) : IEntityStore<Guid, BlogGetDetailResponse>
{
    private const string Endpoint = "/api/v1/blogs";

    public async Task<BlogGetDetailResponse> GetOne(Guid id)
    {
        var response = await HttpClient.GetAsync($"{Endpoint}/{id}");
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadFromJsonAsync<BlogGetDetailResponse>();
        return responseContent!;
    }
}