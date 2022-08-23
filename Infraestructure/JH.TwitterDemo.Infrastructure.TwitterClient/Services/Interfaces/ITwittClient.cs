using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace JH.TwitterDemo.Service.Services.Interfaces
{
    public interface ITwittClient
    {
        IAsyncEnumerable<string> GetTwittsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default);
    }
}