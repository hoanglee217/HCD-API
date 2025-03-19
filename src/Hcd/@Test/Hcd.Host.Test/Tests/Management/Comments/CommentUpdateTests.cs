using Hcd.Contract.Requests.Management.Comments;
using Hcd.Host.Test.Factories.Management;
using Hcd.Host.Test.Setup;
using Hcd.Host.Test.Stores.Management;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.Comments;

public class CommentUpdateTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/comments";

    [Fact]
    public async Task ShouldUpdateCorrectly()
    {
        var factory = new CommentFactory(AuthenticatedClient);
        var newComment = await factory.Create();

        var request = new CommentUpdateRequest()
        {
            Id = newComment.Id,
            // TODO: Update the request properties
            Name = throw new System.NotImplementedException()
        };

        var updateResponse = await AuthenticatedClient.PatchAsJsonAsync($"{_endpoint}/{request.Id}", request);
        updateResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, updateResponse.StatusCode);

        var store = new CommentStore(AuthenticatedClient);
        var updatedComment = await store.GetOne(request.Id);
        Assert.Equal(request.Name, updatedComment.Name);
    }
}