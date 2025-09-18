

using BlogAuthApi.Service.Dtos.Role;

namespace BlogAuthApi.Service.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleDto?> GetByIdAsync(int id);
        Task<RoleDto> CreateAsync(CreateRoleDto dto);
        Task<RoleDto?> UpdateAsync(int id, UpdateRoleDto dto);
        Task<bool> DeleteAsync(int id);
    }

}

