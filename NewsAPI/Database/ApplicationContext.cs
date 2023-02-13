using Microsoft.EntityFrameworkCore;
using NewsAPI.Models;

namespace NewsAPI.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            if(Database.EnsureCreated())
            {
                Posts.Add(new Post()
                {
                    Title = "Test post 1",
                    Content = "Some test to test app",
                    CreatedDate = DateTime.Now.AddDays(-3)
                });

                Posts.Add(new Post()
                {
                    Title = "Another one post",
                    Content = "Some test to test app, hello world",
                    CreatedDate = DateTime.Now.AddDays(-2)
                });

                Posts.Add(new Post()
                {
                    Title = "Test post 3",
                    Content = "Some test to test application",
                    CreatedDate = DateTime.Now.AddHours(-3)
                });

                SaveChanges();
            }
        }

    }
}
