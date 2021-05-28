using netHelpers.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace netHelpers.Framework.Cache.Handler
{
    public class LazyCacheHandler : ILazyCache
    {
        private ICache Cache { get; }

        public LazyCacheHandler(ICache cache)
        {
            Cache = cache;
        }

        public T Get<T>(string key, Func<T> getFromDataStore, TimeSpan? expiration = null)
        {
            Check.NotNull(getFromDataStore, nameof(getFromDataStore));

            var cached = Cache.Get<T>(key);

            if (!EqualityComparer<T>.Default.Equals(cached, default)) return cached;

            cached = getFromDataStore();
            Cache.Set(key, cached, null, expiration);

            return cached;
        }

        public async Task<T> GetAsync<T>(string key, Func<Task<T>> getFromDataStore, TimeSpan? expiration = null)
        {
            Check.NotNull(getFromDataStore, nameof(getFromDataStore));

            var cached = await Cache.GetAsync<T>(key);

            if (!EqualityComparer<T>.Default.Equals(cached, default)) return cached;

            cached = await getFromDataStore();

            if (!EqualityComparer<T>.Default.Equals(cached, default))
                await Cache.SetAsync(key, cached, null, expiration);

            return cached;
        }
    }
}
