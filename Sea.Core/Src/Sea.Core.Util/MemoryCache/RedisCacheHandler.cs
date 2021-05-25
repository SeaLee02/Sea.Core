using Sea.Core.Util.MemoryCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Util
{
    public class RedisCacheHandler : ICaching
    {

        private readonly RedisHelper _helper;

        public RedisCacheHandler(RedisHelper helper)
        {
            _helper = helper;
        }

        public bool Exists(string key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(string key)
        {
            throw new NotImplementedException();
        }

        public string Get(string key)
        {
            return _helper.StringGetAsync<string>(key).GetAwaiter().GetResult();
        }

        public T Get<T>(string key)
        {
            return _helper.StringGetAsync<T>(key).GetAwaiter().GetResult();
        }

        public Task<string> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveByPrefixAsync(string prefix)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string key, T value)
        {
            return _helper.StringSetAsync(key, value).GetAwaiter().GetResult();
        }

        public bool Set<T>(string key, T value, int expires)
        {
            return _helper.StringSetAsync(key, value, new TimeSpan(0, 0, expires, 0)).GetAwaiter().GetResult();
        }

        public Task<bool> SetAsync<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetAsync<T>(string key, T value, int expires)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out string value)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue<T>(string key, out T value)
        {
            throw new NotImplementedException();
        }
    }
}
