using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.Models;

namespace UKFast.API.Client.SafeDNS.Models.Request
{
    public class CreateNoteRequest
    {
        [Newtonsoft.Json.JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
