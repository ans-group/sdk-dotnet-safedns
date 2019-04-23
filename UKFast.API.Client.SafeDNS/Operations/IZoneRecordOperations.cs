using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;
using UKFast.API.Client.Response;
using UKFast.API.Client.SafeDNS.Models;
using UKFast.API.Client.SafeDNS.Models.Request;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public interface IZoneRecordOperations<T> where T : Record
    {
        Task<int> CreateRecordAsync(string zoneName, CreateRecordRequest req);
        Task<IList<T>> GetRecordsAsync(string zoneName, ClientRequestParameters parameters = null);
        Task<Paginated<T>> GetRecordsPaginatedAsync(string zoneName, ClientRequestParameters parameters = null);
        Task<T> GetRecordAsync(string zoneName, int recordID);
        Task UpdateRecordAsync(string zoneName, int recordID, UpdateRecordRequest req);
        Task DeleteRecordAsync(string zoneName, int recordID);
    }
}
