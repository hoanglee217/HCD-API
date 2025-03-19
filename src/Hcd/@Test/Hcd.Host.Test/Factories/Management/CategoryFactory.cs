using Bogus;
using Hcd.Contract.Requests.Management.Categories;
using Esg.Shared.Test.Abstractions;
using Mapster;

namespace Hcd.Host.Test.Factories.Management;

public record CategoryFactory(HttpClient HttpClient) : IEntityFactory<CategoryCreateRequest, CategoryCreateResponse>
{
    private const string Endpoint = "/api/v1/categories";

    public async Task<CategoryCreateResponse> Create(CategoryCreateRequest? baseValue = null)
    {
        var customerRequestFaker = new Faker<CategoryCreateRequest>()
            .RuleFor(x => x.Name, f => f.Person.FirstName);

        var customerRequest = customerRequestFaker.Generate();

        if (baseValue != null)
        {
            customerRequest = baseValue.Adapt(customerRequest);
        }

        var createResponse = await HttpClient.PostAsJsonAsync(Endpoint, customerRequest);
        createResponse.EnsureSuccessStatusCode();
        var createResponseContent = await createResponse.Content.ReadFromJsonAsync<CategoryCreateResponse>();
        return createResponseContent!;
    }

    public async Task CreateMany(int quantity, CategoryCreateRequest? baseValue = null)
    {
        for (var i = 0; i < quantity; i++)
        {
            await Create(baseValue);
        }
    }
}