

namespace BlogAuthApi.Domain
{
    public class BlogImage
    {
        public int Id { get; set; }

        public int BlogId  { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
