using Hcd.Common.Models;
using MediatR;

namespace Hcd.Common.Requests.System.Option;

public class GetAllOptionsRequest : PaginationRequest, IRequest<GetAllOptionsResponse>
{
};
public class GetAllOptionsResponse : PaginationResponse<GetAllOptionsResponseItem>
{
};
public class GetAllOptionsResponseItem
{
    public Guid Id { get; set; }
};