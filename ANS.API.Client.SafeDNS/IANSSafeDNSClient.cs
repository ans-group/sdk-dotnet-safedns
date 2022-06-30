using System.Collections.Generic;
using System.Threading.Tasks;
using ANS.API.Client.SafeDNS.Models;
using ANS.API.Client.SafeDNS.Operations;

namespace ANS.API.Client.SafeDNS
{
    public interface IANSSafeDNSClient : IANSClient
    {
        IZoneOperations<Zone> ZoneOperations();
        IZoneRecordOperations<Record> ZoneRecordOperations();
        IZoneNoteOperations<Note> ZoneNoteOperations();
        ITemplateOperations<Template> TemplateOperations();
        ITemplateRecordOperations<Record> TemplateRecordOperations();
        ISettingsOperations<Settings> SettingsOperations();
    }
}
