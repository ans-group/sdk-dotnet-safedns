using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;
using UKFast.API.Client.Response;
using UKFast.API.Client.SafeDNS.Models;
using UKFast.API.Client.SafeDNS.Models.Request;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public class ZoneNoteOperations<T> : SafeDNSOperations, IZoneNoteOperations<T> where T : Note
    {
        public ZoneNoteOperations(IUKFastSafeDNSClient client) : base(client) { }

        public async Task<int> CreateNoteAsync(string zoneName, CreateNoteRequest req)
        {
            if (string.IsNullOrEmpty(zoneName))
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid zone name");
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
                throw new Client.Exception.UKFastClientValidationException("Invalid zone name");
            }

            return await this.Client.GetPaginatedAsync<T>($"/safedns/v1/zones/{zoneName}/notes", parameters);
        }

        public async Task<T> GetNoteAsync(string zoneName, int noteID)
        {
            if (string.IsNullOrEmpty(zoneName))
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid zone name");
            }
            if (noteID < 1)
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid note id");
            }

            return await this.Client.GetAsync<T>($"/safedns/v1/zones/{zoneName}/notes/{noteID}");
        }
    }
}
