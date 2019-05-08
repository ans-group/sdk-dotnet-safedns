using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;
using UKFast.API.Client.Response;
using UKFast.API.Client.SafeDNS.Models;
using UKFast.API.Client.SafeDNS.Models.Request;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public class TemplateOperations<T> : SafeDNSOperations, ITemplateOperations<T> where T : Template
    {
        public TemplateOperations(IUKFastSafeDNSClient client) : base(client) { }

        public async Task<int> CreateTemplateAsync(CreateTemplateRequest req)
        {
            return (await this.Client.PostAsync<T>($"/safedns/v1/templates", req)).ID;
        }

        public async Task<IList<T>> GetTemplatesAsync(ClientRequestParameters parameters = null)
        {
            return await Client.GetAllAsync(GetTemplatesPaginatedAsync, parameters);
        }

        public async Task<Paginated<T>> GetTemplatesPaginatedAsync(ClientRequestParameters parameters = null)
        {
            return await this.Client.GetPaginatedAsync<T>("/safedns/v1/templates", parameters);
        }

        public async Task<T> GetTemplateAsync(int templateID)
        {
            if (templateID < 1)
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid template id");
            }

            return await this.Client.GetAsync<T>($"/safedns/v1/templates/{templateID}");
        }

        public async Task UpdateTemplateAsync(int templateID, UpdateTemplateRequest req)
        {
            if (templateID < 1)
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid template id");
            }

            await this.Client.PatchAsync($"/safedns/v1/templates/{templateID}", req);
        }

        public async Task DeleteTemplateAsync(int templateID)
        {
            if (templateID < 1)
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid template id");
            }

            await this.Client.DeleteAsync($"/safedns/v1/templates/{templateID}");
        }
    }
}
