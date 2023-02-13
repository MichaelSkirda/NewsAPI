using Swashbuckle.AspNetCore.Annotations;

namespace NewsAPI.Models
{
    /// <summary>
    /// Новость
    /// </summary>
    public class Post
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? URL { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
