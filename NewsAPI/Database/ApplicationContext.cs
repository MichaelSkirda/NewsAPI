using Microsoft.EntityFrameworkCore;
using NewsAPI.Models;

namespace NewsAPI.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<NewsSource> NewsSources { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            if(Database.EnsureCreated())
            {
                // В качестве примера требуется подключить 2 любых новостных сайта на выбор.
                // При помощи NewSource/Post пользователь может добавить RSS другого сайта на свой выбор
                // Изначательно в базе уже есть эти 2 сайта
                NewsSources.Add(new NewsSource()
                {
                    Name = "Russia Today",
                    RssURL = "https://www.rt.com/rss/russia/"
                });

                NewsSources.Add(new NewsSource()
                {
                    Name = "Lenta",
                    RssURL = "https://lenta.ru/rss/news"
                });

                SaveChanges();
            }
        }

    }
}
