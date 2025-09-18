

namespace BlogAuthApi.Service.Dtos.Blog
{
    public class UpdateBlogDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPublished { get; set; } = true;
    }
}
