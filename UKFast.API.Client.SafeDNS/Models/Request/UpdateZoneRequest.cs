using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.Models;

namespace UKFast.API.Client.SafeDNS.Models.Request
{
    public class UpdateZoneRequest
    {
        [Newtonsoft.Json.JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }
}
