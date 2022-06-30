using System;
using System.Collections.Generic;
using System.Text;
using ANS.API.Client.Response;

namespace ANS.API.Client.SafeDNS.Exception
{
    public class ANSSafeDNSTemplateNotFoundException : Client.Exception.ANSClientNotFoundRequestException
    {
        public ANSSafeDNSTemplateNotFoundException(int statusCode, IEnumerable<ClientResponseError> errors) : base(errors) { }
    }
}
