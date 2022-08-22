using System.Collections.Generic;
using System.Threading;

namespace JH.TwitterDemo.Service.Services.Interfaces
{
    public interface ITwittClient
    {
        IAsyncEnumerable<string> GetTwittsAsync(CancellationToken cancellationToken);
    }
}