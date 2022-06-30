using System;
using System.Collections.Generic;
using System.Text;
using ANS.API.Client.Request;
using ANS.API.Client.Models;

namespace ANS.API.Client.SafeDNS.Models.Request
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
