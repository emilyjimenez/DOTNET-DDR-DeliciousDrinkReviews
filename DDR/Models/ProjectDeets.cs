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
    public class Owner
    {
        public string login { get; set; }
        public int id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
    }

    public class ProjectDeets
    {
        public int id { get; set; }
        public string name { get; set; }
        public string html_url { get; set; }
        public string description { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime created_at { get; set; }
       
    }
}
