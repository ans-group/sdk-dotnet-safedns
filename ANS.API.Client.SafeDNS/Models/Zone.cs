using System;
using System.Collections.Generic;
using System.Text;
using ANS.API.Client;
using ANS.API.Client.SafeDNS.Operations;

namespace ANS.API.Client.SafeDNS.Models
{
    public class Zone : Client.Models.ModelBase
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }
    }
}
