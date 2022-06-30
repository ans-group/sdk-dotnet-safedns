using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ANS.API.Client.Models;

namespace ANS.API.Client.SafeDNS.Models.Request
{
    public class CreateRecordRequest
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("type")]
        public string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("content")]
        public string Content { get; set; }

        [Newtonsoft.Json.JsonProperty("priority")]
        public int Priority { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl")]
        public int TTL { get; set; }
    }
}
