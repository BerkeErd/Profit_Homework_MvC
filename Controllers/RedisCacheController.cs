using Microsoft.AspNetCore.Mvc;
using Profit_Homework_MvC.CacheHelper;
using Profit_Homework_MvC.Models;

namespace Profit_Homework_MvC.Controllers
{
    public class RedisCacheController : Controller
    {

        private readonly ICacheService _cacheService;

        public RedisCacheController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        [HttpPost("cache/{key}")]
        public async Task<IActionResult> Get(string key)
        {
            return Ok(await _cacheService.GetValueAsync(key));
        }

        
        public async Task<IActionResult> Post()
        {
            string key = Request.Query["key"];
            string value = Request.Query["value"];
            await _cacheService.SetValueAsync(key, value);
            return Ok();
        }

        [HttpDelete("cache/{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            await _cacheService.Clear(key);
            return Ok();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
