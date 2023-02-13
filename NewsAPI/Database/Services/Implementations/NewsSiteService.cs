using NewsAPI.Models;

namespace NewsAPI.Database.Services.Implementations
{
    public class NewsSourceService : INewsSourceService
    {
        private ApplicationContext db { get; set; }

        public NewsSourceService(ApplicationContext db)
        {
            this.db = db;
        }

        public List<NewsSource> GetAllNewsSources()
        {
            return db.NewsSources.ToList();
        }

        public void AddNewsSource(NewsSource newsSource)
        {
            db.NewsSources.Add(newsSource);
            db.SaveChanges();
        }

    }
}
