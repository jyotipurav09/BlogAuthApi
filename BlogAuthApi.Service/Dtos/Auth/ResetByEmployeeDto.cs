

namespace BlogAuthApi.Service.Dtos.Auth
{
    public class ResetByEmployeeDto
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; } = string.Empty;
    }
}
