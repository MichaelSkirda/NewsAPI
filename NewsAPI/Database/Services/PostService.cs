using NewsAPI.Models;

namespace NewsAPI.Database.Services
{
    public class PostService
    {

        private ApplicationContext db { get; set; }
        private readonly int GetLastPostsCount = 10;

        public PostService(ApplicationContext db)
        {
            this.db = db;
        }

        public List<Post> GetLastPosts()
        {
            return db.Posts.OrderByDescending(p => p.CreatedDate).Take(GetLastPostsCount).ToList();
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
