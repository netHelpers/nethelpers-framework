using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace netHelpers.Framework.Cache
{
    /// <summary>
    /// Contract to implements Cache Provider
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// Get the value from specified key.
        /// </summary>
        /// <param name="key">Key in cache repository.</param>
        /// <returns>Value from specified key.</returns>
        T Get<T>(string key);

        /// <summary>
        /// Get the value from specified key async.
        /// </summary>
        /// <param name="key">Key in cache repository.</param>
        /// <returns>Value from specified key.</returns>
        Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Set an object in Database.
        /// </summary>
        /// <param name="key">Key's object.</param>
        /// <param name="value">Value's object.</param>
        /// <param name="slidingExpireTime">Slide expire time.</param>
        /// <param name="absoluteExpireTime">Absolute expire time.</param>
        bool Set(string key, object value, TimeSpan? slidingExpireTime = default, TimeSpan? absoluteExpireTime = default);

        /// <summary>
        /// Set an object in Database async.
        /// </summary>
        /// <param name="key">Key's object.</param>
        /// <param name="value">Value's object.</param>
        /// <param name="slidingExpireTime">Slide expire time.</param>
        /// <param name="absoluteExpireTime">Absolute expire time.</param>
        Task<bool> SetAsync(string key, object value, TimeSpan? slidingExpireTime = default, TimeSpan? absoluteExpireTime = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove a specified key from cache repository.
        /// </summary>
        /// <param name="key">Key in cache repository.</param>
        bool Remove(string key);

        /// <summary>
        /// Remove a specified key from cache repository async.
        /// </summary>
        /// <param name="key">Key in cache repository.</param>
        Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove multiple Keys
        /// </summary>
        /// <param name="keys">Keys</param>
        /// <returns>True or False</returns>
        bool Remove(string[] keys);

        /// <summary>
        /// Remove multiple Keys async
        /// </summary>
        /// <param name="keys">Keys</param>
        /// <returns>True or False</returns>
        Task<bool> RemoveAsync(string[] keys, CancellationToken cancellationToken = default);

        /// <summary>
        /// Verifie if key exists
        /// </summary>
        /// <param name="key">Key Name</param>
        /// <returns>True or False</returns>
        bool KeyExists(string key);

        /// <summary>
        /// Verifie if key exists async
        /// </summary>
        /// <param name="key">Key Name</param>
        /// <returns>True or False</returns>
        Task<bool> KeyExistsAsync(string key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Set an object in Database.
        /// </summary>
        /// <param name="key">Key's object.</param>
        /// <param name="value">Value's object.</param>
        /// <param name="expiry">Expire timeout</param>
        /// <returns>True or False</returns>
        Task<bool> StringSetAsync(string key, byte[] value, TimeSpan? expiry, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get multiple value from specified key.
        /// </summary>
        /// <typeparam name="keys">Out Type</typeparam>
        /// <param name="key">Key name</param>
        /// <returns>Collection T</returns>
        Task<IEnumerable<T>> StringGetAsync<T>(string[] key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the value from specified key.
        /// </summary>
        /// <typeparam name="T">Out type</typeparam>
        /// <param name="key">Key name</param>
        /// <returns>Value type T</returns>
        Task<T> StringGetAsync<T>(string key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Set multiple objects in Database
        /// </summary>
        /// <typeparam name="keys">Value Type</typeparam>
        /// <param name="keys">KeyValue objects</param>
        /// <returns>True or False</returns>
        Task<bool> StringSetAsync(IDictionary<string, byte[]> keys, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a lock to solve concurrency problems
        /// </summary>
        /// <param name="key">key to be locked</param>
        /// <param name="token">Unique key to identify the lock owner</param>
        /// <param name="lockDuration">Lock timeout</param>
        /// <returns>A lock handler. When disposed it releases the lock automatically.</returns>
        ICacheLock CreateCacheLock(string key, string token, TimeSpan lockDuration);

        /// <summary>
        /// Create list members in Database
        /// </summary>
        /// <param name="key">Unique Key</param>
        /// <param name="member">Member Name</param>
        /// <returns>TRUE or FALSE for insert member</returns>
        Task<bool> SetAddAsync(string key, string member, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create list members in Database
        /// </summary>
        /// <param name="key">Unique Key</param>
        /// <param name="member">Member Name</param>
        /// <returns>TRUE or FALSE for remove member</returns>
        Task<bool> SetRemoveAsync(string key, string member, CancellationToken cancellationToken = default);
    }
}
