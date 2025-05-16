using Hcd.Common.Models;
using Hcd.Common.Requests.Management.Blog;

using Hcd.Data.Entities.Management;

namespace Hcd.Application.Mappings
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Blog, GetAllBlogsResponseItem>
            .NewConfig()
            .Map(dest => dest.BlogCategories, src =>
                src.BlogCategories.Select(bc => new BlogCategoryDto
                {
                    Id = bc.Id,
                    Category = bc.Category != null ? new CategoryDto
                    {
                        Id = bc.Category.Id,
                        Name = bc.Category.Name,
                        CategoryEnums = bc.Category.CategoryEnums
                    } : null
                }).ToList());

            TypeAdapterConfig<PaginationResponse<Blog>, GetAllBlogsResponse>
                .NewConfig();
        }
    }
}