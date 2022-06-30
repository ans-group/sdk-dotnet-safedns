using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ANS.API.Client.Request;
using ANS.API.Client.Models;

namespace ANS.API.Client.SafeDNS.Models.Request
{
    public class UpdateTemplateRequest
    {
        /// <summary>
        /// Name of template
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Specifies whether template is default
        /// </summary>
        [Newtonsoft.Json.JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Default { get; set; }
    }
}
