using Microsoft.AspNetCore.Mvc;
using NewsAPI.Database.Services;
using NewsAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private PostService service;

        public PostController(PostService service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<Post> Get()
        {
            return service.GetLastPosts();
        }

        [HttpGet("{substring}")]
        public List<Post> Get(string substring)
        {
            return service.GetPostByTitleSubstring(substring);
        }

        [HttpPost]
        public void Post([FromBody] Post post)
        {
        }


    }
}
