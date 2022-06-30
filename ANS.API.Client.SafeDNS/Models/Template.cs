
using System;
using System.Collections.Generic;
using System.Text;
using ANS.API.Client;
using ANS.API.Client.Json;
using ANS.API.Client.SafeDNS.Operations;

namespace ANS.API.Client.SafeDNS.Models
{
    public class Template : Client.Models.ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public int ID { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("default")]
        public bool? Default { get; set; }

        [Newtonsoft.Json.JsonProperty("created_at")]
        [Newtonsoft.Json.JsonConverter(typeof(DateConverter))]
        public DateTime CreatedAt { get; set; }
    }
}
