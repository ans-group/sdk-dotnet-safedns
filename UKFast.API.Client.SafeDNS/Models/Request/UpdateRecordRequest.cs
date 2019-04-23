using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.Models;

namespace UKFast.API.Client.SafeDNS.Models.Request
{
    public class UpdateRecordRequest
    {
        [Newtonsoft.Json.JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [Newtonsoft.Json.JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
        public int? Priority { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl", NullValueHandling = NullValueHandling.Ignore)]
        public int? TTL { get; set; }
    }
}
