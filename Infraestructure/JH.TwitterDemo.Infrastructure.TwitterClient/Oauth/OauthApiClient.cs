
using JH.TwitterDemo.Service.Oauth.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Service.Oauth
{
    //public class OauthApiClient : IOauthApiClient
    //{
    //    private readonly IOptions<OauthDataConfig> options;
    //    public OauthApiClient(IOptions<OauthDataConfig> options)
    //    {
    //        this.options = options;
    //    }
    //    public async Task<OauthToken> RequestJWTUserToken()
    //    {
           
           
    //        //var authHeaderFormat = "Basic {0}";
    //        //var authHeader = string.Format(authHeaderFormat,
    //        //     Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(this.options.Value.ApiKey)
    //        //+ ":" +
    //        //Uri.EscapeDataString((this.options.Value.ApiSecret)))
    //        //));

    //        //var req = new HttpClient();
    //        //req.DefaultRequestHeaders.Add("Authorization", authHeader);

    //        //HttpRequestMessage msg = new HttpRequestMessage(new HttpMethod("POST"), options.Value.OAuthUrl);
    //        //msg.Content = new HttpStringContent("grant_type=client_credentials");
    //        //msg.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/x-www-form-urlencoded");

    //        //HttpResponseMessage response = await req.SendRequestAsync(msg);

    //        //TwitAuthenticateResponse twitAuthResponse;
    //        //using (response)
    //        //{
    //        //    string objectText = await response.Content.ReadAsStringAsync();
    //        //    twitAuthResponse = JSonSerialiserHelper.Deserialize<TwitAuthenticateResponse>(objectText);
    //        //}
    //    }
    //}
}
