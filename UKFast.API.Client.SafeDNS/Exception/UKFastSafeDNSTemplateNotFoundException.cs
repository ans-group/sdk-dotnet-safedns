using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.Response;

namespace UKFast.API.Client.SafeDNS.Exception
{
    public class UKFastSafeDNSTemplateNotFoundException : Client.Exception.UKFastClientNotFoundRequestException
    {
        public UKFastSafeDNSTemplateNotFoundException(int statusCode, IEnumerable<ClientResponseError> errors) : base(errors) { }
    }
}
