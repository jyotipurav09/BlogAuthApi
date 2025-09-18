

using BlogAuthApi.Service.Dtos.Blog;

namespace BlogAuthApi.Service.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDto>> GetAllAsync();
        Task<BlogDto?> GetByIdAsync(int id);
        Task<BlogDto> CreateAsync(CreateBlogDto dto);
        Task<BlogDto?> UpdateAsync(int id, UpdateBlogDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
