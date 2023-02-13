using NewsAPI.Models;

namespace NewsAPI.Database.Services.Implementations
{
    public class PostService : IPostService
    {
        private ApplicationContext db { get; set; }

        public PostService(ApplicationContext db)
        {
            this.db = db;
        }

        public List<Post> GetLastPosts(int count)
        {
            return db.Posts.OrderByDescending(p => p.CreatedDate).Take(count).ToList();
        }


        public List<Post> GetPostByTitleSubstring(string substring)
        {
            return db.Posts.Where(p => p.Title.Contains(substring)).ToList();
        }

        public void CreatePost(Post post)
        {
            if (db.Posts.FirstOrDefault(p => p.Title == post.Title) != null)
                throw new InvalidOperationException($"Post with title '{post.Title}' already exists");

            db.Posts.Add(post);
            db.SaveChanges();
        }

    }
}
