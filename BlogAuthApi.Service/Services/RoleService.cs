using BlogAuthApi.Data.Repositories;
using BlogAuthApi.Domain;
using BlogAuthApi.Service.Dtos.Role;
using BlogAuthApi.Service.Interfaces;

namespace BlogAuthApi.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;


        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync() ;
            return roles.Select(r => new RoleDto { Id = r.Id, Name = r.Name });
        }

        public async Task<RoleDto?> GetByIdAsync(int id)
        {
            var role = await _repository.GetByIdAsync(id);
            if (role == null) return null;

            return new RoleDto { Id = role.Id, Name = role.Name };
        }

        public async Task<RoleDto> CreateAsync(CreateRoleDto dto)
        {
            var role = new Role { Name = dto.Name };
            var created = await _repository.AddAsync(role);
            return new RoleDto { Id = created.Id, Name = created.Name };
        }

        public async Task<RoleDto?> UpdateAsync(int id, UpdateRoleDto dto)
        {
            var role = new Role { Id = id, Name = dto.Name };
            var updated = await _repository.UpdateAsync(role);
            if (updated == null) return null;

            return new RoleDto { Id = updated.Id, Name = updated.Name };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
