using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.Response;

namespace UKFast.API.Client.SafeDNS.Exception
{
    public class UKFastSafeDNSZoneNotFoundException : Client.Exception.UKFastClientNotFoundRequestException
    {
        public UKFastSafeDNSZoneNotFoundException(IEnumerable<ClientResponseError> errors) : base(errors) { }
    }
}
