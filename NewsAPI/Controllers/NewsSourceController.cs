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

        /// <summary>
        /// Возвращает список всех сайтов, с которых берутся новости
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<NewsSource> Get()
        {
            return service.GetAllNewsSources();
        }

        /// <summary>
        /// Добавляет сайт в список сайтов для парсинга новостей. Парсинг происходит раз в минуту.
        /// </summary>
        /// <param name="newsSource"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] NewsSource newsSource)
        {
            service.AddNewsSource(newsSource);
            return Ok();
        }

    }
}
