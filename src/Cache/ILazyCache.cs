using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace netHelpers.Framework.Cache
{
    public interface ILazyCache
    {
        /// <summary>
        /// Get value from cache or falls back to <paramref name="getFromDataStore" /> in case of cache miss.
        /// </summary>
        /// <param name="key">Key in cache repository.</param>
        /// <param name="getFromDataStore">Function responsible for getting the value from the data store.</param>
        /// <param name="expiration">expire time.</param>
        /// <returns>Value from specified key.</returns>
        T Get<T>(string key, Func<T> getFromDataStore, TimeSpan? expiration = default);

        /// <summary>
        /// Async Get value from cache or falls back to <paramref name="getFromDataStore" /> in case of cache miss.
        /// </summary>
        /// <param name="key">Key in cache repository.</param>
        /// <param name="getFromDataStore">Function responsible for getting the value from the data store.</param>
        /// <param name="expiration">expire time.</param>
        /// <returns>Value from specified key.</returns>
        Task<T> GetAsync<T>(string key, Func<Task<T>> getFromDataStore, TimeSpan? expiration = default, CancellationToken cancellationToken = default);
    }
}
