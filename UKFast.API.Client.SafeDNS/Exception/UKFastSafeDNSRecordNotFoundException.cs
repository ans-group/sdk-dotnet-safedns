using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.Response;

namespace UKFast.API.Client.SafeDNS.Exception
{
    public class UKFastSafeDNSRecordNotFoundException : Client.Exception.UKFastClientNotFoundRequestException
    {
        public UKFastSafeDNSRecordNotFoundException(IEnumerable<ClientResponseError> errors) : base(errors) { }
    }
}
