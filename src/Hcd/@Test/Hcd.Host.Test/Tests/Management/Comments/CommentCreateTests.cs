using Hcd.Contract.Requests.Management.Comments;
using Hcd.Host.Test.Setup;
using Hcd.Host.Test.Stores.Management;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.Comments;

public class CommentCreateTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/comments";

    [Fact]
    public async Task ShouldCreateCorrectly()
    {
        var request = new CommentCreateRequest()
        {
            // TODO: Add the request properties
            Name = throw new System.NotImplementedException(),
        };

        var createResponse = await AuthenticatedClient.PostAsJsonAsync(_endpoint, request);
        createResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.Created, createResponse.StatusCode);
        
        // Response data should not be null
        var createResponseData = await createResponse.Content.ReadFromJsonAsync<CommentCreateResponse>();
        Assert.NotNull(createResponseData);

        // Check if created
        var store = new CommentStore(AuthenticatedClient);
        var comment = await store.GetOne(createResponseData.Id);
        Assert.Equal(request.Name, comment.Name);
    }
}