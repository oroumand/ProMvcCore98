using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session17.StateManagement.Controllers
{
    public class MemoryCacheController : Controller
    {
        private readonly IMemoryCache memoryCache;

        public MemoryCacheController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            SetCache("FirstName", "LastName");
            GetCache("FirstName");
            return View();
        }
        private void SetCache(string key,string value)
        {
            //var options = new MemoryCacheEntryOptions();

            memoryCache.Set(key, value);//, options);
        }

        private void GetCache(string key)
        {
            
            var resutl = memoryCache.Get(key);
        }
    }
}
