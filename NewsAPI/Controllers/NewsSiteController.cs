using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Database.Services;
using NewsAPI.Models;

namespace NewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsSourceController : ControllerBase
    {

        private INewsSourceService service;

        public NewsSourceController(INewsSourceService service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<NewsSource> Get()
        {
            return service.GetAllNewsSources();
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewsSource newsSource)
        {
            service.AddNewsSource(newsSource);
            return Ok();
        }

    }
}
