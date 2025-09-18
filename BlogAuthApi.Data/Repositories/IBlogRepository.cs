

using BlogAuthApi.Domain;

namespace BlogAuthApi.Data.Repositories
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(int id);
        Task<Blog> AddAsync(Blog blog);
        Task<Blog?> UpdateAsync(Blog blog);
        Task<bool> DeleteAsync(int id);
    
}
}
