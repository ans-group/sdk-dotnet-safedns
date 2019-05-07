using System;
using UKFast.API.Client.Json;

namespace UKFast.API.Client.SafeDNS.Models
{
    public class Note : Client.Models.ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public int ID { get; set; }

        [Newtonsoft.Json.JsonProperty("contact_id")]
        public int ContactID { get; set; }

        [Newtonsoft.Json.JsonProperty("notes")]
        public string Notes { get; set; }

        [Newtonsoft.Json.JsonProperty("created_at")]
        [Newtonsoft.Json.JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("ip")]
        public string IP { get; set; }
    }
}
