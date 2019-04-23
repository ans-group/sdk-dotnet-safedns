using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;
using UKFast.API.Client.Response;
using UKFast.API.Client.SafeDNS.Models;
using UKFast.API.Client.SafeDNS.Models.Request;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public interface IZoneNoteOperations<T> where T : Note
    {
        Task<int> CreateNoteAsync(string zoneName, CreateNoteRequest req);
        Task<IList<T>> GetNotesAsync(string zoneName, ClientRequestParameters parameters = null);
        Task<Paginated<T>> GetNotesPaginatedAsync(string zoneName, ClientRequestParameters parameters = null);
        Task<T> GetNoteAsync(string zoneName, int noteID);
    }
}
