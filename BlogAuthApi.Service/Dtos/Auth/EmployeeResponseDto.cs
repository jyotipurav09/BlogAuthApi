

namespace BlogAuthApi.Service.Dtos.Auth
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; } 
        public string? Email { get; set; }
        public string? Role { get; set; }
        public bool IsEnabled { get; set; }
    }
}
