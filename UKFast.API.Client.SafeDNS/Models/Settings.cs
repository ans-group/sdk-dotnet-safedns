namespace UKFast.API.Client.SafeDNS.Models
{
    public class Settings : Client.Models.ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public int ID { get; set; }

        [Newtonsoft.Json.JsonProperty("email")]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty("nameservers")]
        public Nameserver[] Nameservers { get; set; }

        [Newtonsoft.Json.JsonProperty("custom_soa_allowed")]
        public bool CustomSOAAllowed { get; set; }

        [Newtonsoft.Json.JsonProperty("custom_base_ns_allowed")]
        public bool CustomBaseNSAllowed { get; set; }

        [Newtonsoft.Json.JsonProperty("custom_axfr")]
        public CustomAXFRSettings CustomAXFR { get; set; }

        [Newtonsoft.Json.JsonProperty("delegation_allowed")]
        public bool DelegationAllowed { get; set; }

        [Newtonsoft.Json.JsonProperty("product")]
        public string Product { get; set; }
    }

    public class Nameserver
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("ip")]
        public string IP { get; set; }
    }

    public class CustomAXFRSettings
    {
        [Newtonsoft.Json.JsonProperty("allowed")]
        public bool Allowed { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string[] Name { get; set; }

        [Newtonsoft.Json.JsonProperty("ip")]
        public string[] IP { get; set; }
    }
}