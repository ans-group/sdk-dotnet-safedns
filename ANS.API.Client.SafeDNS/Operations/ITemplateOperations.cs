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
