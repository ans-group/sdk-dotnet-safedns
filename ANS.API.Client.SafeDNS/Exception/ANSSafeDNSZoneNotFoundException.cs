using System;
using System.Collections.Generic;
using System.Text;
using ANS.API.Client.Response;

namespace ANS.API.Client.SafeDNS.Exception
{
    public class ANSSafeDNSZoneNotFoundException : Client.Exception.ANSClientNotFoundRequestException
    {
        public ANSSafeDNSZoneNotFoundException(IEnumerable<ClientResponseError> errors) : base(errors) { }
    }
}
