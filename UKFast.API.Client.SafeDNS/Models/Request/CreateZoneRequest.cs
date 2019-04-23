using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.Request;
using UKFast.API.Client.Models;

namespace UKFast.API.Client.SafeDNS.Models.Request
{
    public class CreateZoneRequest
    {
        /// <summary>
        /// Name of zone
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Note for zone
        /// </summary>
        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }
    }
}
