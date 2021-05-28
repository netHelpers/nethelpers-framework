using System;
using System.Collections.Generic;
using System.Text;

namespace netHelpers.Framework.Cache
{
    public interface ICacheLock : IDisposable
    {
        bool Success { get; }
    }
}
