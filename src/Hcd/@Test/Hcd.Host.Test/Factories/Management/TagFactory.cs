using Bogus;
using Hcd.Contract.Requests.Management.Tags;
using Esg.Shared.Test.Abstractions;
using Mapster;

namespace Hcd.Host.Test.Factories.Management;

public record TagFactory(HttpClient HttpClient) : IEntityFactory<TagCreateRequest, TagCreateResponse>
{
    private const string Endpoint = "/api/v1/tags";

    public async Task<TagCreateResponse> Create(TagCreateRequest? baseValue = null)
    {
        var customerRequestFaker = new Faker<TagCreateRequest>()
            .RuleFor(x => x.Name, f => f.Person.FirstName);

        var customerRequest = customerRequestFaker.Generate();

        if (baseValue != null)
        {
            customerRequest = baseValue.Adapt(customerRequest);
        }

        var createResponse = await HttpClient.PostAsJsonAsync(Endpoint, customerRequest);
        createResponse.EnsureSuccessStatusCode();
        var createResponseContent = await createResponse.Content.ReadFromJsonAsync<TagCreateResponse>();
        return createResponseContent!;
    }

    public async Task CreateMany(int quantity, TagCreateRequest? baseValue = null)
    {
        for (var i = 0; i < quantity; i++)
        {
            await Create(baseValue);
        }
    }
}