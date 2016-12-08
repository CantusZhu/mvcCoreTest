using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace mvcCoreTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public HomeController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Index()
        {

            try
            {
                string cacheKey = "key";

                string result;
                if (!_memoryCache.TryGetValue(cacheKey, out result))
                {
                    result = $"哈哈哈{DateTime.Now.AddYears(1)}哈哈哈";
                    _memoryCache.Set(cacheKey, result);
                }
                ViewBag.Cache = result;
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
            
    }
}