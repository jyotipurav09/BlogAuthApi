

using BlogAuthApi.Domain;
using BlogAuthApi.Service.Dtos.Auth;

namespace BlogAuthApi.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto);
        Task<EmployeeDto?> UpdateAsync(int id, UpdateEmployeeDto dto);
        Task<bool> DeleteAsync(int id);
        Task <bool> ToggleEnabledAsync(int id, bool isEnabled);
        Task<bool> ChangeRoleAsync(int id, int newRoleId);
    }
}
   

    










