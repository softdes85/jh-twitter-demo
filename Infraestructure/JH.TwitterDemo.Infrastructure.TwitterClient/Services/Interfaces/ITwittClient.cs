
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Service.Services.Interfaces
{
    public interface ITwittClient
    {
        IAsyncEnumerable<string> GetTwittsAsync( CancellationToken cancellationToken);
    }
}
