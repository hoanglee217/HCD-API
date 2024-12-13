using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Category;

public class CreateCategoryRequestHandler(CategoryService categoryService) : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
{
    public Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        return categoryService.CreateCategory(request);
    }
}