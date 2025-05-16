using Bogus;
using Hcd.Contract.Requests.Management.BlogTags;
using Esg.Shared.Test.Abstractions;
using Mapster;

namespace Hcd.Host.Test.Factories.Management;

public record BlogTagFactory(HttpClient HttpClient) : IEntityFactory<BlogTagCreateRequest, BlogTagCreateResponse>
{
    private const string Endpoint = "/api/v1/blog-tags";

    public async Task<BlogTagCreateResponse> Create(BlogTagCreateRequest? baseValue = null)
    {
        var customerRequestFaker = new Faker<BlogTagCreateRequest>()
            .RuleFor(x => x.Name, f => f.Person.FirstName);

        var customerRequest = customerRequestFaker.Generate();

        if (baseValue != null)
        {
            customerRequest = baseValue.Adapt(customerRequest);
        }

        var createResponse = await HttpClient.PostAsJsonAsync(Endpoint, customerRequest);
        createResponse.EnsureSuccessStatusCode();
        var createResponseContent = await createResponse.Content.ReadFromJsonAsync<BlogTagCreateResponse>();
        return createResponseContent!;
    }

    public async Task CreateMany(int quantity, BlogTagCreateRequest? baseValue = null)
    {
        for (var i = 0; i < quantity; i++)
        {
            await Create(baseValue);
        }
    }
}