using System;
using System.Collections.Generic;
using System.Text;
using ANS.API.Client.Response;

namespace ANS.API.Client.SafeDNS.Exception
{
    public class ANSSafeDNSRecordNotFoundException : Client.Exception.ANSClientNotFoundRequestException
    {
        public ANSSafeDNSRecordNotFoundException(IEnumerable<ClientResponseError> errors) : base(errors) { }
    }
}
