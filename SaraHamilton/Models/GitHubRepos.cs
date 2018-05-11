using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SaraHamilton.Models
{
    public class GitHubRepos
    {
        public string Name { get; set; }
        public string Html_Url { get; set; }
        public string Created_At { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }

        public static List<GitHubRepos> GetGitHubRepos()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("users/Sara-Hamilton/starred?sort=created&direction=asc", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddHeader("header", "application/vnd.github.v3+json");
            request.AddHeader("User-Agent", EnvironmentVariables.AccountUserAgent);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var repoList = JsonConvert.DeserializeObject<List<GitHubRepos>>(jsonResponse.ToString());
            return repoList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
