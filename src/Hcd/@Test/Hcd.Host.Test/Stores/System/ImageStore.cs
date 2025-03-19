using Hcd.Contract.Requests.System.Images;
using Esg.Shared.Test.Abstractions;

namespace Hcd.Host.Test.Stores.System;

public record ImageStore(HttpClient HttpClient) : IEntityStore<Guid, ImageGetDetailResponse>
{
    private const string Endpoint = "/api/v1/images";

    public async Task<ImageGetDetailResponse> GetOne(Guid id)
    {
        var response = await HttpClient.GetAsync($"{Endpoint}/{id}");
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadFromJsonAsync<ImageGetDetailResponse>();
        return responseContent!;
    }
}