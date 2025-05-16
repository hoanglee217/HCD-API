using Hcd.Common.Interfaces.Abstractions;
using Hcd.Common.Requests.Management.Blog;
using Hcd.Data.Entities.Management;
using Hcd.Data.Instances;

namespace Hcd.Application.Managers.Management
{
    public class BlogManager(IManagementRepository<Blog> blogRepository,
                             IManagementRepository<BlogCategory> blogCategoryRepository,
                             IManagementRepository<BlogTag> blogTagRepository,
                             IManagementRepository<Tag> tagRepository
                             )
    : ManagementDomainService<Blog>(blogRepository)
    {
        public async Task UpdateCategoriesAsync(Guid blogId, List<Guid>? categoriesName)
        {
            // Lấy danh sách danh mục hiện có của blog
            var existingCategories = await blogCategoryRepository
                .GetAll()
                .Where(bc => bc.BlogId == blogId)
                .ToListAsync();

            if (categoriesName == null || categoriesName.Count == 0)
            {
                blogCategoryRepository.RemoveRange(existingCategories);
                return;
            }

            var existingCategoryIds = existingCategories.Select(bc => bc.CategoryId).ToList();

            // Xác định danh mục cần thêm
            var categoriesToAdd = categoriesName
                .Where(id => !existingCategoryIds.Contains(id))
                .Select(id => new { BlogId = blogId, CategoryId = id })
                .ToList();

            // Xác định danh mục cần xóa
            var categoriesToRemove = existingCategories
                .Where(bc => !categoriesName.Contains(bc.CategoryId))
                .ToList();

            // Thêm danh mục mới
            if (categoriesToAdd.Any())
            {
                blogCategoryRepository.AddRange(categoriesToAdd.Adapt<List<BlogCategory>>());
            }

            // Xóa danh mục không còn trong request
            if (categoriesToRemove.Any())
            {
                blogCategoryRepository.RemoveRange(categoriesToRemove);
            }
        }

        public async Task UpdateTagsAsync(Guid blogId, List<string>? tags)
        {
            // Lấy danh sách các tag hiện tại của blog
            var existingBlogTags = await blogTagRepository
                .GetAll()
                .Where(bt => bt.BlogId == blogId)
                .ToListAsync();

            if (tags == null || tags.Count == 0)
            {
                blogTagRepository.RemoveRange(existingBlogTags);
                return;
            }

            var existingTagIds = existingBlogTags.Select(bt => bt.TagId).ToList();

            // Lấy danh sách các tag đã tồn tại trong DB
            var existingTags = await tagRepository
                .GetAll()
                .Where(t => tags.Contains(t.Name))
                .ToListAsync();

            var existingTagNames = existingTags.Select(t => t.Name).ToList();

            // Tạo danh sách tag chưa có trong DB
            var newTags = tags
                .Where(tag => !existingTagNames.Contains(tag))
                .Select(tag => new Tag { Id = Guid.NewGuid(), Name = tag })
                .ToList();

            if (newTags.Count > 0)
            {
                tagRepository.AddRange(newTags);
            }
            
            var mergeAll = newTags.Union(existingTags).ToList();

            var mergeAllIds = mergeAll.Select(t => t.Id).ToList();

            // Xác định tag cần thêm vào blog
            var tagsToAdd = mergeAllIds
                .Where(id => !existingTagIds.Contains(id))
                .Select(id => new { BlogId = blogId, TagId = id })
                .ToList();

            // Xác định tag cần xóa khỏi blog
            var tagsToRemove = existingBlogTags
                .Where(bt => !mergeAllIds.Contains(bt.TagId))
                .ToList();

            // Thêm mới các BlogTag
            if (tagsToAdd.Count > 0)
            {
                blogTagRepository.AddRange(tagsToAdd.Adapt<List<BlogTag>>());
            }

            // Xóa các BlogTag không còn tồn tại
            if (tagsToRemove.Count > 0)
            {
                blogTagRepository.RemoveRange(tagsToRemove);
            }
        }
    }
}