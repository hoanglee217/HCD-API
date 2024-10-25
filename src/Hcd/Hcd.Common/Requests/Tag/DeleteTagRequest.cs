using MediatR;

namespace Hcd.Common.Requests.Tag;

public class DeleteTagRequest : IRequest
{
    public Guid Id { get; set; }
};