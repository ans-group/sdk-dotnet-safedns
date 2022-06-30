using System;
using System.Collections.Generic;
using System.Text;
using ANS.API.Client.Response;

namespace ANS.API.Client.SafeDNS.Exception
{
    public class ANSSafeDNSZoneNoteNotFoundException : Client.Exception.ANSClientNotFoundRequestException
    {
        public ANSSafeDNSZoneNoteNotFoundException(int statusCode, IEnumerable<ClientResponseError> errors) : base(errors) { }
    }
}
