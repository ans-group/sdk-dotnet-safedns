using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.SafeDNS.Models.Request
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
