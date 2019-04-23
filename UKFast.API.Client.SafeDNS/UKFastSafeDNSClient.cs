using System;
using UKFast.API.Client;
using UKFast.API.Client.SafeDNS.Models;
using UKFast.API.Client.SafeDNS.Operations;

namespace UKFast.API.Client.SafeDNS
{
    public class UKFastSafeDNSClient : UKFastClient, IUKFastSafeDNSClient
    {
        public UKFastSafeDNSClient(IConnection connection) : base(connection)
        {
        }

        public UKFastSafeDNSClient(IConnection connection, ClientConfig config) : base(connection, config)
        {
        }

        public IZoneOperations<Zone> ZoneOperations()
        {
            return new ZoneOperations(this);
        }

        public IZoneRecordOperations<Record> ZoneRecordOperations()
        {
            return new ZoneRecordOperations(this);
        }

        public IZoneNoteOperations<Note> ZoneNoteOperations()
        {
            return new ZoneNoteOperations(this);
        }

        public ITemplateOperations<Template> TemplateOperations()
        {
            return new TemplateOperations(this);
        }

        public ITemplateRecordOperations<Record> TemplateRecordOperations()
        {
            return new TemplateRecordOperations(this);
        }
    }
}
