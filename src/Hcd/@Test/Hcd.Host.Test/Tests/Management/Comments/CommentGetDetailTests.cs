using Hcd.Contract.Requests.Management.Comments;
using Hcd.Host.Test.Factories.Management;
using Hcd.Host.Test.Setup;
using Esg.Shared.Test.Integration;

namespace Hcd.Host.Test.Tests.Management.Comments;

public class CommentGetDetailTests(WebApplication<ManagementAppFactory, Program> app) : ManagementTest(app)
{
    private const string _endpoint = "/api/v1/comments";

    [Fact]
    public async Task ShouldGetDetailCorrectly()
    {
        var factory = new CommentFactory(AuthenticatedClient);
        var newComment = await factory.Create();

        var getAllResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/{newComment.Id}");
        getAllResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, getAllResponse.StatusCode);

        var comment = await getAllResponse.Content.ReadFromJsonAsync<CommentGetDetailResponse>();
        Assert.NotNull(comment);
        Assert.Equal(newComment.Id, comment.Id);
    }

    [Fact]
    public async Task ShouldReturnNotFound()
    {
        var getAllResponse = await AuthenticatedClient.GetAsync($"{_endpoint}/00000000-0000-0000-0000-000000000000");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, getAllResponse.StatusCode);
    }
}