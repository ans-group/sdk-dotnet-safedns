using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.SafeDNS.Models;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public class TemplateRecordOperations : TemplateRecordOperationsBase<Record>, ITemplateRecordOperations<Record>
    {
        public TemplateRecordOperations(IUKFastSafeDNSClient client) : base(client) { }
    }
}
