using System;
using ANS.API.Client;
using ANS.API.Client.SafeDNS.Models;
using ANS.API.Client.SafeDNS.Operations;

namespace ANS.API.Client.SafeDNS
{
    public class ANSSafeDNSClient : ANSClient, IANSSafeDNSClient
    {
        public ANSSafeDNSClient(IConnection connection) : base(connection)
        {
        }

        public ANSSafeDNSClient(IConnection connection, ClientConfig config) : base(connection, config)
        {
        }

        public IZoneOperations<Zone> ZoneOperations()
        {
            return new ZoneOperations<Zone>(this);
        }

        public IZoneRecordOperations<Record> ZoneRecordOperations()
        {
            return new ZoneRecordOperations<Record>(this);
        }

        public IZoneNoteOperations<Note> ZoneNoteOperations()
        {
            return new ZoneNoteOperations<Note>(this);
        }

        public ITemplateOperations<Template> TemplateOperations()
        {
            return new TemplateOperations<Template>(this);
        }

        public ITemplateRecordOperations<Record> TemplateRecordOperations()
        {
            return new TemplateRecordOperations<Record>(this);
        }

        public ISettingsOperations<Settings> SettingsOperations()
        {
            return new SettingsOperations<Settings>(this);
        }
    }
}
