using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ANS.API.Client.Models;
using ANS.API.Client.Request;
using ANS.API.Client.Response;
using ANS.API.Client.SafeDNS.Models;
using ANS.API.Client.SafeDNS.Models.Request;

namespace ANS.API.Client.SafeDNS.Operations
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
