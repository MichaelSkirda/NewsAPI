using Swashbuckle.AspNetCore.Annotations;

namespace NewsAPI.Models
{
    /// <summary>
    /// С этого ресурса по RssURL будут парситься новости
    /// </summary>
    public class NewsSource
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RssURL { get; set; }
    }
}
