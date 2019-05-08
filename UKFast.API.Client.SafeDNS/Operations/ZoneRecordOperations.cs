using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;
using UKFast.API.Client.Response;
using UKFast.API.Client.SafeDNS.Models;
using UKFast.API.Client.SafeDNS.Models.Request;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public class ZoneRecordOperations<T> : SafeDNSOperations, IZoneRecordOperations<T> where T : Record
    {

        public ZoneRecordOperations(IUKFastSafeDNSClient client) : base(client) { }

        public async Task<int> CreateRecordAsync(string zoneName, CreateRecordRequest req)
        {
            if (string.IsNullOrEmpty(zoneName))
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid zone name");
            }

            return (await this.Client.PostAsync<Record>($"/safedns/v1/zones/{zoneName}/records", req)).ID;
        }

        public async Task<IList<T>> GetRecordsAsync(string zoneName, ClientRequestParameters parameters = null)
        {
            return await Client.GetAllAsync((ClientRequestParameters funcParameters) => GetRecordsPaginatedAsync(zoneName, funcParameters), parameters);
        }

        public async Task<Paginated<T>> GetRecordsPaginatedAsync(string zoneName, ClientRequestParameters parameters = null)
        {
            if (string.IsNullOrEmpty(zoneName))
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid zone name");
            }

            return await this.Client.GetPaginatedAsync<T>($"/safedns/v1/zones/{zoneName}/records", parameters);
        }

        public async Task<T> GetRecordAsync(string zoneName, int recordID)
        {
            if (string.IsNullOrEmpty(zoneName))
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid zone name");
            }
            if (recordID < 1)
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid record id");
            }

            return await this.Client.GetAsync<T>($"/safedns/v1/zones/{zoneName}/records/{recordID}");
        }

        public async Task UpdateRecordAsync(string zoneName, int recordID, UpdateRecordRequest req)
        {
            if (string.IsNullOrEmpty(zoneName))
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid zone name");
            }
            if (recordID < 1)
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid record id");
            }

            await this.Client.PatchAsync($"/safedns/v1/zones/{zoneName}/records/{recordID}", req);
        }

        public async Task DeleteRecordAsync(string zoneName, int recordID)
        {
            if (string.IsNullOrEmpty(zoneName))
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid zone name");
            }
            if (recordID < 1)
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid record id");
            }

            await this.Client.GetAsync<T>($"/safedns/v1/zones/{zoneName}/records/{recordID}");
        }
    }
}
