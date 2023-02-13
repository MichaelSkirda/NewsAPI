using NewsAPI.Models;

namespace NewsAPI.Database.Services
{
    public interface IPostService
    {
        void CreatePost(Post post);
        List<Post> GetLastPosts(int count);
        List<Post> GetPostByTitleSubstring(string substring);
    }
}