

using BlogAuthApi.Domain;
using BlogAuthApi.Service.Dtos.Blog;

namespace BlogAuthApi.Service.Interfaces
{
    public interface IBlogService
    {
        Task<IReadOnlyList<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(int id);

        Task<Blog> CreateAsync(int userId, BlogCreateDto dto);
        Task UpdateAsync(int userId, int BlogId, BlogUpdateDto dto);
        Task DeleteAsync(int userId, int BlogId);
    }
}
