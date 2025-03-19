using Hcd.Contract.Requests.Management.Comments;
using Esg.Shared.Test.Abstractions;

namespace Hcd.Host.Test.Stores.Management;

public record CommentStore(HttpClient HttpClient) : IEntityStore<Guid, CommentGetDetailResponse>
{
    private const string Endpoint = "/api/v1/comments";

    public async Task<CommentGetDetailResponse> GetOne(Guid id)
    {
        var response = await HttpClient.GetAsync($"{Endpoint}/{id}");
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadFromJsonAsync<CommentGetDetailResponse>();
        return responseContent!;
    }
}