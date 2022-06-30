using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ANS.API.Client.Models;
using ANS.API.Client.Request;

namespace ANS.API.Client.SafeDNS.Models.Request
{
    public class CreateTemplateRequest
    {
        /// <summary>
        /// Name of template
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Specifies whether template is default
        /// </summary>
        [Newtonsoft.Json.JsonProperty("default")]
        public bool Default { get; set; }
    }
}
