using Bogus;
using Hcd.Contract.Requests.System.Images;
using Esg.Shared.Test.Abstractions;
using Mapster;

namespace Hcd.Host.Test.Factories.System;

public record ImageFactory(HttpClient HttpClient) : IEntityFactory<ImageCreateRequest, ImageCreateResponse>
{
    private const string Endpoint = "/api/v1/images";

    public async Task<ImageCreateResponse> Create(ImageCreateRequest? baseValue = null)
    {
        var customerRequestFaker = new Faker<ImageCreateRequest>()
            .RuleFor(x => x.Name, f => f.Person.FirstName);

        var customerRequest = customerRequestFaker.Generate();

        if (baseValue != null)
        {
            customerRequest = baseValue.Adapt(customerRequest);
        }

        var createResponse = await HttpClient.PostAsJsonAsync(Endpoint, customerRequest);
        createResponse.EnsureSuccessStatusCode();
        var createResponseContent = await createResponse.Content.ReadFromJsonAsync<ImageCreateResponse>();
        return createResponseContent!;
    }

    public async Task CreateMany(int quantity, ImageCreateRequest? baseValue = null)
    {
        for (var i = 0; i < quantity; i++)
        {
            await Create(baseValue);
        }
    }
}