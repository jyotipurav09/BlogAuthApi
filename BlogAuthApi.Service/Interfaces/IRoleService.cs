

using BlogAuthApi.Domain;

namespace BlogAuthApi.Service.Interfaces
{
    public interface IRoleService
    {
        Task<IReadOnlyList<Role>> GetAllAsync();
        Task<Role> CreateAsync(Role role);
        Task UpdateAsync(Role role);
        Task DeleteAsync(int id);

    }
}
