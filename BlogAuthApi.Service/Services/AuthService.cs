
using BlogAuthApi.Data.Data;
using BlogAuthApi.Domain;
using BlogAuthApi.Service.Dtos.Auth;
using BlogAuthApi.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogAuthApi.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly PasswordHasher<Employee> _passwordHasher;

        public AuthService(DataContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<Employee>();
        }

        // ✅ Register User
        public async Task<UserResponseDto> RegisterAsync(CreateUserDto dto)
        {
            var user = new Employee
            {
                FirstName = dto.UserName,
                Email = dto.Email,
                RoleId = 3, // Default: User
                IsEnabled = true,
                CreatedAt = DateTime.UtcNow
            };

            // Password hashing
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            await _context.Employees.AddAsync(user);
            await _context.SaveChangesAsync();

            return new UserResponseDto
            {
                Id = user.Id,
                UserName = user.FirstName,
                Email = user.Email,
                Role = "User"
            };
        }

        //  Login User
        public async Task<UserResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _context.Employees.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null)
                throw new Exception("Invalid email or password");

            // Password verify
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Invalid email or password");

            return new UserResponseDto
            {
                Id = user.Id,
                UserName = user.FirstName,
                Email = user.Email,
                Role = "User",
                Token = "" // Token add होगा controller में
            };
        }

        //  Change Password
        public async Task<bool> ChangePasswordAsync(ChangePasswordDto dto)
        {
            var user = await _context.Employees.FindAsync(dto.UserId);
            if (user == null) throw new Exception("Invalid user");

            // Verify current password
            var verify = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.CurrentPassword);
            if (verify == PasswordVerificationResult.Failed)
                throw new Exception("Current password is incorrect");

            // Hash new password
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.NewPassword);
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        // Forgot Password
        public async Task<bool> ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            var user = await _context.Employees.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null) throw new Exception("Email not found");

            // Normally: Generate reset token and send via email
            return true;
        }

        // ✅ Reset Password
        public async Task<bool> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _context.Employees.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null) throw new Exception("Invalid email");

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.NewPassword);
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        // Reset by Admin/Employee
        public async Task<bool> ResetByEmployeeAsync(ResetByEmployeeDto dto)
        {
            var user = await _context.Employees.FindAsync(dto.UserId);
            if (user == null) throw new Exception("Invalid user");

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.NewPassword);
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
