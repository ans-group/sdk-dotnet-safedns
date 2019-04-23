using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.SafeDNS.Models;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public class ZoneRecordOperations : ZoneRecordActionsBase<Record>, IZoneRecordOperations<Record>
    {
        public ZoneRecordOperations(IUKFastSafeDNSClient client) : base(client) { }
    }
}
