using System;
using UKFast.API.Client.Json;

namespace UKFast.API.Client.SafeDNS.Models
{
    public class Record : Client.Models.ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public int ID { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("template_id")]
        public int? TemplateID { get; set; }

        [Newtonsoft.Json.JsonProperty("type")]
        public string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("content")]
        public string Content { get; set; }

        [Newtonsoft.Json.JsonProperty("priority")]
        public int Priority { get; set; }

        [Newtonsoft.Json.JsonProperty("updated_at")]
        [Newtonsoft.Json.JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl")]
        public int TTL { get; set; }
    }
}
