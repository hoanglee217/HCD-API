using MediatR;

namespace Hcd.Common.Requests.System.Option;

public class UpdateOptionRequest : IRequest<UpdateOptionResponse>
{
    public Guid Id { get; set; }
};
public class UpdateOptionResponse
{
    public Guid Id { get; set; }
};