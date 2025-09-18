

namespace BlogAuthApi.Domain
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int CreatedByEmployeeId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; } 

        public bool IsPublished { get; set; } = true;
        public Employee? Employee { get; set; }

    }
}
