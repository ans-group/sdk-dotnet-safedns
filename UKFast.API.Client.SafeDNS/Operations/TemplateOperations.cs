using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.SafeDNS.Models;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public class TemplateOperations : TemplateOperationsBase<Template>, ITemplateOperations<Template>
    {
        public TemplateOperations(IUKFastSafeDNSClient client) : base(client) { }
    }
}
