using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.Response;

namespace UKFast.API.Client.SafeDNS.Exception
{
    public class UKFastSafeDNSZoneNoteNotFoundException : Client.Exception.UKFastClientNotFoundRequestException
    {
        public UKFastSafeDNSZoneNoteNotFoundException(int statusCode, IEnumerable<ClientResponseError> errors) : base(errors) { }
    }
}
