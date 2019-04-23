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
    public interface ITemplateRecordOperations<T> where T : Record
    {
        Task<int> CreateRecordAsync(int templateID, CreateRecordRequest req);
        Task<IList<T>> GetRecordsAsync(int templateID, ClientRequestParameters parameters = null);
        Task<Paginated<T>> GetRecordsPaginatedAsync(int templateID, ClientRequestParameters parameters = null);
        Task<T> GetRecordAsync(int templateID, int recordID);
        Task UpdateRecordAsync(int templateID, int recordID, UpdateRecordRequest req);
        Task DeleteRecordAsync(int templateID, int recordID);
    }
}
