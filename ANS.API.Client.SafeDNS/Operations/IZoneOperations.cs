using System.Collections.Generic;
using System.Threading.Tasks;
using ANS.API.Client.Models;
using ANS.API.Client.Request;
using ANS.API.Client.Response;
using ANS.API.Client.SafeDNS.Models;
using ANS.API.Client.SafeDNS.Models.Request;

namespace ANS.API.Client.SafeDNS.Operations
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
