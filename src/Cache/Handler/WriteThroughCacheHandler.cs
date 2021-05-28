using netHelpers.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace netHelpers.Framework.Cache.Handler
{
    public class WriteThroughCacheHandler : IWriteThroughCache
    {
        private ICache Cache { get; }

        public WriteThroughCacheHandler(ICache cache)
        {
            Cache = cache;
        }

        public bool Remove(string key, Func<bool> removeFromDataStore)
        {
            return Run(
                removeFromDataStore,
                () => Cache.Remove(key));
        }

        public async Task<bool> RemoveAsync(string key, Func<Task<bool>> removeFromDataStore)
        {
            return await RunAsync(
                removeFromDataStore,
                () => Cache.RemoveAsync(key));
        }

        public bool Set(string key, object value, Func<bool> saveToDataStore, TimeSpan? expiration = null)
        {
            return Run(
                saveToDataStore,
                () => Cache.Set(key, value, null, expiration));
        }

        public async Task<bool> SetAsync(string key, object value, Func<Task<bool>> saveToDataStore, TimeSpan? expiration = null)
        {
            return await RunAsync(
                saveToDataStore,
                () => Cache.SetAsync(key, value, null, expiration));
        }

        private bool Run(Func<bool> updateDataStore, Func<bool> updateCache)
        {
            _ = Check.NotNull(updateDataStore, nameof(updateDataStore));
            _ = Check.NotNull(updateCache, nameof(updateCache));

            return updateDataStore() && updateCache();
        }

        private async Task<bool> RunAsync(Func<Task<bool>> updateDataStore, Func<Task<bool>> updateCache)
        {
            _ = Check.NotNull(updateDataStore, nameof(updateDataStore));
            _ = Check.NotNull(updateCache, nameof(updateCache));

            return (await updateDataStore()) && (await updateCache());
        }
    }
}
