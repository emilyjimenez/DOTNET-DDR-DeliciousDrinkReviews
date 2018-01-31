using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace DDR.Models
{
    public class Project
    {

        public static List<ProjectDeets> GetProjects()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("users/emilyjimenez/starred", Method.GET);
            request.AddHeader("User-Agent", "emilyjimenez");
            request.AddParameter("direction", "asc");

            var response = new RestResponse();


            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            List<ProjectDeets> jsonResponse = JsonConvert.DeserializeObject<List<ProjectDeets>>(response.Content);
            var topThree = jsonResponse.Take(3).ToList();
            return topThree;
        }   

        public static Task<IRestResponse> GetResponseContentAsync(RestClient GHClient, RestRequest GHRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            GHClient.ExecuteAsync(GHRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
