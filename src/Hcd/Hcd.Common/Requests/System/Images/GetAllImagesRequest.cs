using Hcd.Common.Models;
using MediatR;

namespace Hcd.Common.Requests.System.Images;

public class GetAllImagesRequest : PaginationRequest, IRequest<GetAllImagesResponse>
{
}

public class GetAllImagesResponse : PaginationResponse<GetAllImagesResponseItem>
{
}

public class GetAllImagesResponseItem
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}