

using BlogAuthApi.Data.Data;
using BlogAuthApi.Domain;
using BlogAuthApi.Service.Dtos.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogAuthApi.Service.Services
{
    public class EmployeeService
    {
        private readonly DataContext _context;
        private readonly PasswordHasher<Employee> _passwordHasher;

        public EmployeeService(DataContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<Employee>();
        }

        // Get All Employees
        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            return await _context.Employees
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    Email = e.Email,
                    RoleId = e.RoleId,
                    IsEnabled = e.IsEnabled
                })
                .ToListAsync();
        }

        //  Get Employee by Id
        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return null;

            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                Email = employee.Email,
                RoleId = employee.RoleId,
                IsEnabled = employee.IsEnabled
            };
        }

        //  Create Employee
        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                Email = dto.Email,
                RoleId = dto.RoleId,
                IsEnabled = true,
                CreatedAt = DateTime.UtcNow
            };

            // Password Hashing
            employee.PasswordHash = _passwordHasher.HashPassword(employee, dto.Password);

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                Email = employee.Email,
                RoleId = employee.RoleId,
                IsEnabled = employee.IsEnabled
            };
        }

        //  Update Employee
        public async Task<EmployeeDto?> UpdateAsync(int id, UpdateEmployeeDto dto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return null;

            employee.FirstName = dto.FirstName;
            employee.Email = dto.Email;
            employee.RoleId = dto.RoleId;
            employee.IsEnabled = dto.IsEnabled;
            employee.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                Email = employee.Email,
                RoleId = employee.RoleId,
                IsEnabled = employee.IsEnabled
            };
        }

        //  Delete Employee
        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
