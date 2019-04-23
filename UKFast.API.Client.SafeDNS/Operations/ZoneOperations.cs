using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.SafeDNS.Models;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public class ZoneOperations : ZoneOperationsBase<Zone>, IZoneOperations<Zone>
    {
        public ZoneOperations(IUKFastSafeDNSClient client) : base(client) { }
    }
}
