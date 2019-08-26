using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session17.StateManagement.Infrastructures
{
    public interface ICacheProvider
    {
        string Get(string key);
        string Set(string key, string valeu);
    }

    public class InMemory : ICacheProvider
    {
        private readonly IMemoryCache memoryCache;

        public InMemory(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public string Get(string key)
        {
            throw new NotImplementedException();
        }

        public string Set(string key, string valeu)
        {
            throw new NotImplementedException();
        }
    }
    public class DistributedCache : ICacheProvider
    {
        private readonly IDistributedCache distributedCache;

        public DistributedCache(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }
        public string Get(string key)
        {
            throw new NotImplementedException();
        }

        public string Set(string key, string valeu)
        {
            throw new NotImplementedException();
        }
    }
}
