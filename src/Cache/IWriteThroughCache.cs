using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace netHelpers.Framework.Cache
{
    public interface IWriteThroughCache
    {
        /// <summary>
        /// Set an object in Redis Database after successfully saving the object to the data store (<paramref name="saveToDataStore"/>).
        /// </summary>
        /// <param name="key">Key's object.</param>
        /// <param name="value">Value's object.</param>
        /// <param name="saveToDataStore">Function responsible for saving the object to the data store.</param>
        /// <param name="expiration"> expire time.</param>
        bool Set(string key, object value, Func<bool> saveToDataStore, TimeSpan? expiration = default);
        Task<bool> SetAsync(string key, object value, Func<Task<bool>> saveToDataStore, TimeSpan? expiration = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove a specified key from Redis Database after successfully removing the object from the data store (<paramref name="removeFromDataStore"/>).
        /// </summary>
        /// <param name="key">Key in cache repository.</param>
        /// <param name="removeFromDataStore">Function responsible for removing the object from the data store.</param>
        bool Remove(string key, Func<bool> removeFromDataStore);
        Task<bool> RemoveAsync(string key, Func<Task<bool>> removeFromDataStore, CancellationToken cancellationToken = default);
    }
}
