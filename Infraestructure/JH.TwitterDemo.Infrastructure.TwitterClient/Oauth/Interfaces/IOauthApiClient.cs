using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Service.Oauth.Interfaces
{
    public interface IOauthApiClient
    {
        Task<OauthToken> RequestJWTUserToken();
    }
}
