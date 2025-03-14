using MediatR;

namespace Hcd.Common.Requests.Management.Tag;

public class DeleteTagRequest : IRequest
{
    public Guid Id { get; set; }
};