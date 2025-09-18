

using BlogAuthApi.Data.Repositories;
using BlogAuthApi.Domain;
using BlogAuthApi.Service.Dtos.Blog;
using BlogAuthApi.Service.Interfaces;

namespace BlogAuthApi.Service.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;

        public BlogService(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BlogDto>> GetAllAsync()
        {
            var blogs = await _repository.GetAllAsync();
            return blogs.Select(b => new BlogDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                CreatedByEmployeeId = b.CreatedByEmployeeId,
                AuthorName = b.Employee?.FirstName,
                CreatedAt = b.CreatedAt,
                UpdatedAt = b.UpdatedAt,
                IsPublished = b.IsPublished
            });
        }

        public async Task<BlogDto?> GetByIdAsync(int id)
        {
            var blog = await _repository.GetByIdAsync(id);
            if (blog == null) return null;

            return new BlogDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                CreatedByEmployeeId = blog.CreatedByEmployeeId,
                AuthorName = blog.Employee?.FirstName,
                CreatedAt = blog.CreatedAt,
                UpdatedAt = blog.UpdatedAt,
                IsPublished = blog.IsPublished
            };
        }

        public async Task<BlogDto> CreateAsync(CreateBlogDto dto)
        {
            var blog = new Blog
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedByEmployeeId = dto.CreatedByEmployeeId,
                CreatedAt = DateTime.UtcNow,
                IsPublished = dto.IsPublished
            };

            var created = await _repository.AddAsync(blog);

            return new BlogDto
            {
                Id = created.Id,
                Title = created.Title,
                Description = created.Description,
                CreatedByEmployeeId = created.CreatedByEmployeeId,
                AuthorName = created.Employee?.FirstName,
                CreatedAt = created.CreatedAt,
                IsPublished = created.IsPublished
            };
        }

        public async Task<BlogDto?> UpdateAsync(int id, UpdateBlogDto dto)
        {
            var blog = new Blog
            {
                Id = id,
                Title = dto.Title,
                Description = dto.Description,
                IsPublished = dto.IsPublished
            };

            var updated = await _repository.UpdateAsync(blog);
            if (updated == null) return null;

            return new BlogDto
            {
                Id = updated.Id,
                Title = updated.Title,
                Description = updated.Description,
                CreatedByEmployeeId = updated.CreatedByEmployeeId,
                AuthorName = updated.Employee?.FirstName,
                CreatedAt = updated.CreatedAt,
                UpdatedAt = updated.UpdatedAt,
                IsPublished = updated.IsPublished
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
