using System.Collections.Generic;
using System.Threading.Tasks;
using ANS.API.Client.Models;
using ANS.API.Client.Request;
using ANS.API.Client.Response;
using ANS.API.Client.SafeDNS.Models;
using ANS.API.Client.SafeDNS.Models.Request;

namespace ANS.API.Client.SafeDNS.Operations
{
    public class TemplateRecordOperations<T> : SafeDNSOperations, ITemplateRecordOperations<T> where T : Record
    {
        public TemplateRecordOperations(IANSSafeDNSClient client) : base(client) { }

        public async Task<int> CreateRecordAsync(int templateID, CreateRecordRequest req)
        {
            if (templateID < 1)
            {
                throw new Client.Exception.ANSClientValidationException("Invalid template id");
            }

            return (await this.Client.PostAsync<T>($"/safedns/v1/templates/{templateID}/records", req)).ID;
        }

        public async Task<IList<T>> GetRecordsAsync(int templateID, ClientRequestParameters parameters = null)
        {
            return await Client.GetAllAsync((ClientRequestParameters funcParameters) => GetRecordsPaginatedAsync(templateID, funcParameters), parameters);
        }

        public async Task<Paginated<T>> GetRecordsPaginatedAsync(int templateID, ClientRequestParameters parameters = null)
        {
            if (templateID < 1)
            {
                throw new Client.Exception.ANSClientValidationException("Invalid template id");
            }

            return await this.Client.GetPaginatedAsync<T>($"/safedns/v1/templates/{templateID}/records", parameters);
        }

        public async Task<T> GetRecordAsync(int templateID, int recordID)
        {
            if (templateID < 1)
            {
                throw new Client.Exception.ANSClientValidationException("Invalid template id");
            }
            if (recordID < 1)
            {
                throw new Client.Exception.ANSClientValidationException("Invalid record id");
            }

            return await this.Client.GetAsync<T>($"/safedns/v1/templates/{templateID}/records/{recordID}");
        }

        public async Task UpdateRecordAsync(int templateID, int recordID, UpdateRecordRequest req)
        {
            if (templateID < 1)
            {
                throw new Client.Exception.ANSClientValidationException("Invalid template id");
            }
            if (recordID < 1)
            {
                throw new Client.Exception.ANSClientValidationException("Invalid record id");
            }

            await this.Client.PatchAsync($"/safedns/v1/templates/{templateID}/records/{recordID}", req);
        }

        public async Task DeleteRecordAsync(int templateID, int recordID)
        {
            if (templateID < 1)
            {
                throw new Client.Exception.ANSClientValidationException("Invalid template id");
            }
            if (recordID < 1)
            {
                throw new Client.Exception.ANSClientValidationException("Invalid record id");
            }

            await this.Client.DeleteAsync($"/safedns/v1/templates/{templateID}/records/{recordID}");
        }
    }
}
