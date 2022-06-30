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
