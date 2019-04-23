using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client;
using UKFast.API.Client.SafeDNS.Operations;

namespace UKFast.API.Client.SafeDNS.Models
{
    public class Zone : Client.Models.ModelBase
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }
    }
}
