using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.SafeDNS.Models;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public class ZoneNoteOperations : ZoneNoteOperationsBase<Note>, IZoneNoteOperations<Note>
    {
        public ZoneNoteOperations(IUKFastSafeDNSClient client) : base(client) { }
    }
}
