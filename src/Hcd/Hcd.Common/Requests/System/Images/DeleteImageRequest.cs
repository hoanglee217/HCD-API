using MediatR;

namespace Hcd.Common.Requests.System.Images;

public class DeleteImageRequest: IRequest
{
    public Guid Id { get; set; }
}