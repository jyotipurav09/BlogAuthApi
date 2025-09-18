

namespace BlogAuthApi.Service.Dtos.Auth
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? Email { get; set; }
        public int RoleId { get; set; }
        public bool IsEnabled { get; set; }
    }
}
