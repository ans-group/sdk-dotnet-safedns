using System.Collections.Generic;
using System.Threading.Tasks;
using ANS.API.Client.Models;
using ANS.API.Client.Request;
using ANS.API.Client.Response;
using ANS.API.Client.SafeDNS.Models;
using ANS.API.Client.SafeDNS.Models.Request;

namespace ANS.API.Client.SafeDNS.Operations
{
    public class TemplateOperations<T> : SafeDNSOperations, ITemplateOperations<T> where T : Template
    {
        public TemplateOperations(IANSSafeDNSClient client) : base(client) { }

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
                throw new Client.Exception.ANSClientValidationException("Invalid template id");
            }

            return await this.Client.GetAsync<T>($"/safedns/v1/templates/{templateID}");
        }

        public async Task UpdateTemplateAsync(int templateID, UpdateTemplateRequest req)
        {
            if (templateID < 1)
            {
                throw new Client.Exception.ANSClientValidationException("Invalid template id");
            }

            await this.Client.PatchAsync($"/safedns/v1/templates/{templateID}", req);
        }

        public async Task DeleteTemplateAsync(int templateID)
        {
            if (templateID < 1)
            {
                throw new Client.Exception.ANSClientValidationException("Invalid template id");
            }

            await this.Client.DeleteAsync($"/safedns/v1/templates/{templateID}");
        }
    }
}
