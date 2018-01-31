using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DDR.Models
{
    public class Project
    {

        public static async Task<List<Project>> GetProjects()
        {
            var client = new RestClient("https://api.github.com");

            var request = new RestRequest("users/emilyjimenez/starred", Method.GET);
            request.AddHeader("User-Agent", "emilyjimenez");
            request.AddParameter("direction", "asc");

            var response = new RestResponse()
                Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
                        
                        
                        )
        }
    }
}
