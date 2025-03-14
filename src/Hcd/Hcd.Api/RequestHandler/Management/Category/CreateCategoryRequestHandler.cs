using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.Category;

public class CreateCategoryRequestHandler(CategoryService categoryService) : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
{
    public Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        return categoryService.CreateCategory(request);
    }
}