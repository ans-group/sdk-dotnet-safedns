using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;
using UKFast.API.Client.Response;
using UKFast.API.Client.SafeDNS.Models;
using UKFast.API.Client.SafeDNS.Models.Request;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public abstract class ZoneOperationsBase<T> : SafeDNSOperations where T : Models.Zone
    {

        public ZoneOperationsBase(IUKFastSafeDNSClient client) : base(client) { }

        public async Task<string> CreateZoneAsync(CreateZoneRequest req)
        {
            return (await this.Client.PostAsync<T>($"/safedns/v1/zones", req)).Name;
        }

        public async Task<IList<T>> GetZonesAsync(ClientRequestParameters parameters = null)
        {
            return await Client.GetAllAsync(GetZonesPaginatedAsync, parameters);
        }

        public async Task<Paginated<T>> GetZonesPaginatedAsync(ClientRequestParameters parameters = null)
        {
            return await this.Client.GetPaginatedAsync<T>("/safedns/v1/zones", parameters);
        }

        public async Task<T> GetZoneAsync(string zoneName)
        {
            if (string.IsNullOrEmpty(zoneName))
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid zone name");
            }

            return await this.Client.GetAsync<T>($"/safedns/v1/zones/{zoneName}");
        }

        public async Task UpdateZoneAsync(string zoneName, UpdateZoneRequest req)
        {
            if (string.IsNullOrEmpty(zoneName))
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid zone name");
            }

            await this.Client.PatchAsync($"/safedns/v1/zones/{zoneName}", req);
        }

        public async Task DeleteZoneAsync(string zoneName)
        {
            if (string.IsNullOrEmpty(zoneName))
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid zone name");
            }

            await this.Client.DeleteAsync($"/safedns/v1/zones/{zoneName}");
        }
    }
}
