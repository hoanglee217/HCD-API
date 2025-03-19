using Bogus;
using Hcd.Contract.Requests.Management.Comments;
using Esg.Shared.Test.Abstractions;
using Mapster;

namespace Hcd.Host.Test.Factories.Management;

public record CommentFactory(HttpClient HttpClient) : IEntityFactory<CommentCreateRequest, CommentCreateResponse>
{
    private const string Endpoint = "/api/v1/comments";

    public async Task<CommentCreateResponse> Create(CommentCreateRequest? baseValue = null)
    {
        var customerRequestFaker = new Faker<CommentCreateRequest>()
            .RuleFor(x => x.Name, f => f.Person.FirstName);

        var customerRequest = customerRequestFaker.Generate();

        if (baseValue != null)
        {
            customerRequest = baseValue.Adapt(customerRequest);
        }

        var createResponse = await HttpClient.PostAsJsonAsync(Endpoint, customerRequest);
        createResponse.EnsureSuccessStatusCode();
        var createResponseContent = await createResponse.Content.ReadFromJsonAsync<CommentCreateResponse>();
        return createResponseContent!;
    }

    public async Task CreateMany(int quantity, CommentCreateRequest? baseValue = null)
    {
        for (var i = 0; i < quantity; i++)
        {
            await Create(baseValue);
        }
    }
}