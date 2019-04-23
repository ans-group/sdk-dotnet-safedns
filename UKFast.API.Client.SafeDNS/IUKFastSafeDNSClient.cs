using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.SafeDNS.Models;
using UKFast.API.Client.SafeDNS.Operations;

namespace UKFast.API.Client.SafeDNS
{
    public interface IUKFastSafeDNSClient : IUKFastClient
    {
        IZoneOperations<Zone> ZoneOperations();
        IZoneRecordOperations<Record> ZoneRecordOperations();
        IZoneNoteOperations<Note> ZoneNoteOperations();
        ITemplateOperations<Template> TemplateOperations();
        ITemplateRecordOperations<Record> TemplateRecordOperations();
    }
}
