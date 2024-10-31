using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Category;

public class CreateCategoryRequestHandler(ICategoryService categoryService) : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
{
    public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        return await categoryService.CreateCategory(request, cancellationToken);
    }
}