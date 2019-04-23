using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;
using UKFast.API.Client.Response;
using UKFast.API.Client.SafeDNS.Models;
using UKFast.API.Client.SafeDNS.Models.Request;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public interface IZoneOperations<T> where T : Zone
    {
        Task<string> CreateZoneAsync(CreateZoneRequest zone);
        Task<IList<T>> GetZonesAsync(ClientRequestParameters parameters = null);
        Task<Paginated<T>> GetZonesPaginatedAsync(ClientRequestParameters parameters = null);
        Task<T> GetZoneAsync(string zoneName);
        Task UpdateZoneAsync(string zoneName, UpdateZoneRequest req);
        Task DeleteZoneAsync(string zoneName);
    }
}
