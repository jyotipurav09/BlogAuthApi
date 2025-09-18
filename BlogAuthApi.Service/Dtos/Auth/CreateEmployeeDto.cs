

namespace BlogAuthApi.Service.Dtos.Auth
{
    public class CreateEmployeeDto
    {
        public string FirstName { get; set; }= string.Empty;
        public string Email { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
