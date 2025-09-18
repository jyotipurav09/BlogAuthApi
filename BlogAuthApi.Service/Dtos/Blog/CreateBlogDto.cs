

namespace BlogAuthApi.Service.Dtos.Blog
{
    public class CreateBlogDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CreatedByEmployeeId { get; set; }
        public bool IsPublished { get; set; } = true;
    }
}
