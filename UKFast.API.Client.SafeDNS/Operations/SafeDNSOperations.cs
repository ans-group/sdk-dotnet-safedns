using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.Operations;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public abstract class SafeDNSOperations : OperationsBase<IUKFastSafeDNSClient>
    {
        public SafeDNSOperations(IUKFastSafeDNSClient client) : base(client) { }
    }
}
