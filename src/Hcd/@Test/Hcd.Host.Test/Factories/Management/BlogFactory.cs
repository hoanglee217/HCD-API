using Bogus;
using Hcd.Contract.Requests.Management.Blogs;
using Esg.Shared.Test.Abstractions;
using Mapster;

namespace Hcd.Host.Test.Factories.Management;

public record BlogFactory(HttpClient HttpClient) : IEntityFactory<BlogCreateRequest, BlogCreateResponse>
{
    private const string Endpoint = "/api/v1/blogs";

    public async Task<BlogCreateResponse> Create(BlogCreateRequest? baseValue = null)
    {
        var customerRequestFaker = new Faker<BlogCreateRequest>()
            .RuleFor(x => x.Name, f => f.Person.FirstName);

        var customerRequest = customerRequestFaker.Generate();

        if (baseValue != null)
        {
            customerRequest = baseValue.Adapt(customerRequest);
        }

        var createResponse = await HttpClient.PostAsJsonAsync(Endpoint, customerRequest);
        createResponse.EnsureSuccessStatusCode();
        var createResponseContent = await createResponse.Content.ReadFromJsonAsync<BlogCreateResponse>();
        return createResponseContent!;
    }

    public async Task CreateMany(int quantity, BlogCreateRequest? baseValue = null)
    {
        for (var i = 0; i < quantity; i++)
        {
            await Create(baseValue);
        }
    }
}