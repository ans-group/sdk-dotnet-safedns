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
    public interface ITemplateOperations<T> where T : Template
    {
        Task<int> CreateTemplateAsync(CreateTemplateRequest req);
        Task<IList<T>> GetTemplatesAsync(ClientRequestParameters parameters = null);
        Task<Paginated<T>> GetTemplatesPaginatedAsync(ClientRequestParameters parameters = null);
        Task<T> GetTemplateAsync(int templateID);
        Task UpdateTemplateAsync(int templateID, UpdateTemplateRequest req);
        Task DeleteTemplateAsync(int templateID);
    }
}
