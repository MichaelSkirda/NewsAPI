using NewsAPI.Models;

namespace NewsAPI.Database.Services
{
    public interface INewsSourceService
    {
        void AddNewsSource(NewsSource newsSource);
        List<NewsSource> GetAllNewsSources();
    }
}