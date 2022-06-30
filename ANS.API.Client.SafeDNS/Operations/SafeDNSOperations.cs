using System;
using System.Collections.Generic;
using System.Text;
using ANS.API.Client.Operations;

namespace ANS.API.Client.SafeDNS.Operations
{
    public abstract class SafeDNSOperations : OperationsBase<IANSSafeDNSClient>
    {
        public SafeDNSOperations(IANSSafeDNSClient client) : base(client) { }
    }
}
