using System;
using System.Collections.Generic;
using System.Text;
using ANS.API.Client.Models;

namespace ANS.API.Client.SafeDNS.Models.Request
{
    public class CreateNoteRequest
    {
        [Newtonsoft.Json.JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
