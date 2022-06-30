using System.Collections.Generic;
using System.Threading.Tasks;
using ANS.API.Client.Models;
using ANS.API.Client.Request;
using ANS.API.Client.Response;
using ANS.API.Client.SafeDNS.Models;
using ANS.API.Client.SafeDNS.Models.Request;

namespace ANS.API.Client.SafeDNS.Operations
{
    public class ZoneNoteOperations<T> : SafeDNSOperations, IZoneNoteOperations<T> where T : Note
    {
        public ZoneNoteOperations(IANSSafeDNSClient client) : base(client) { }

        public async Task<int> CreateNoteAsync(string zoneName, CreateNoteRequest req)
        {
            if (string.IsNullOrEmpty(zoneName))
            {
                throw new Client.Exception.ANSClientValidationException("Invalid zone name");
            }

            return (await this.Client.PostAsync<Note>($"/safedns/v1/zones/{zoneName}/notes", req)).ID;
        }

        public async Task<IList<T>> GetNotesAsync(string zoneName, ClientRequestParameters parameters = null)
        {
            return await Client.GetAllAsync((ClientRequestParameters funcParameters) => GetNotesPaginatedAsync(zoneName, funcParameters), parameters);
        }

        public async Task<Paginated<T>> GetNotesPaginatedAsync(string zoneName, ClientRequestParameters parameters = null)
        {
            if (string.IsNullOrEmpty(zoneName))
            {
                throw new Client.Exception.ANSClientValidationException("Invalid zone name");
            }

            return await this.Client.GetPaginatedAsync<T>($"/safedns/v1/zones/{zoneName}/notes", parameters);
        }

        public async Task<T> GetNoteAsync(string zoneName, int noteID)
        {
            if (string.IsNullOrEmpty(zoneName))
            {
                throw new Client.Exception.ANSClientValidationException("Invalid zone name");
            }
            if (noteID < 1)
            {
                throw new Client.Exception.ANSClientValidationException("Invalid note id");
            }

            return await this.Client.GetAsync<T>($"/safedns/v1/zones/{zoneName}/notes/{noteID}");
        }
    }
}
