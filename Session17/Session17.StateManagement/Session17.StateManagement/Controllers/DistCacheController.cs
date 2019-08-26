using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Session17.StateManagement.Infrastructures;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session17.StateManagement.Controllers
{
    public class DistCacheController : Controller
    {
        private readonly IDistributedCache _cache;
        private readonly ICacheProvider cacheProvider;

        public DistCacheController(IDistributedCache memoryCache, ICacheProvider cacheProvider)
        {
            this._cache = memoryCache;
            this.cacheProvider = cacheProvider;
        }
        public IActionResult Index()
        {
            SetCache("FirstName", "LastName");
            GetCache("FirstName");
            return View();
        }
        private void SetCache(string key, string value)
        {
            //var options = new MemoryCacheEntryOptions();
            _cache.SetString(key, value);
            //_cache.Set(key, value);//, options);
        }

        private void GetCache(string key)
        {

            var resutl = _cache.Get(key);
        }
    }
}
