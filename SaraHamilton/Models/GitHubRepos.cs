using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace SaraHamilton.Models
{
    public class GitHubRepos
    {
        public string Name { get; set; }
        public string Html_Url { get; set; }
        public string Created_At { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
    }
}
