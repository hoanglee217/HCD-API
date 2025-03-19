using Hcd.Host.Test.Factories;
using Hcd.Host.Test.Factories.Management;
using Hcd.Host.Test.Setup;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.Comments;

public class CommentDeleteTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/comments";

    [Fact]
    public async Task ShouldDeleteCorrectly()
    {
        var factory = new CommentFactory(AuthenticatedClient);
        var newComment = await factory.Create();

        var deleteResponse = await AuthenticatedClient.DeleteAsync($"{_endpoint}/{newComment.Id}");
        deleteResponse.EnsureSuccessStatusCode();

        // Check status code
        Assert.Equal(System.Net.HttpStatusCode.OK, deleteResponse.StatusCode);

        // Check if deleted
        var getOneResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/{newComment.Id}");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, getOneResponse.StatusCode);
    }
}