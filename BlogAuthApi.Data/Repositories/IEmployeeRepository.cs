

using BlogAuthApi.Domain;

namespace BlogAuthApi.Data.Repositories
{
    public interface IEmployeeRepository
    {
       Task<IEnumerable<Employee>>GetAllAsync();
      Task<Employee?>GetByIdAsync(int id);
      Task<Employee?>GetByEmailAsync(string email);
      Task AddAsync(Employee employee);
      Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}
