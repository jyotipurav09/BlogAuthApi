
using BlogAuthApi.Service.Dtos.Auth;


namespace BlogAuthApi.Service.Interfaces
{
    public interface IAuthService
    {
        Task<UserResponseDto> RegisterAsync(CreateUserDto dto);
        Task<UserResponseDto> LoginAsync(LoginDto dto);
        Task<bool> ChangePasswordAsync(ChangePasswordDto dto);
        Task<bool> ForgotPasswordAsync(ForgotPasswordDto dto);
        Task<bool> ResetPasswordAsync(ResetPasswordDto dto);
        Task<bool> ResetByEmployeeAsync(ResetByEmployeeDto dto);
    
}
}

    

    