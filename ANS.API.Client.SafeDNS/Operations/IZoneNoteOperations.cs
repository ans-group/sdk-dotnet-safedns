using System.Collections.Generic;
using System.Threading.Tasks;
using ANS.API.Client.Models;
using ANS.API.Client.Request;
using ANS.API.Client.Response;
using ANS.API.Client.SafeDNS.Models;
using ANS.API.Client.SafeDNS.Models.Request;

namespace ANS.API.Client.SafeDNS.Operations
{
    public interface IZoneNoteOperations<T> where T : Note
    {
        Task<int> CreateNoteAsync(string zoneName, CreateNoteRequest req);
        Task<IList<T>> GetNotesAsync(string zoneName, ClientRequestParameters parameters = null);
        Task<Paginated<T>> GetNotesPaginatedAsync(string zoneName, ClientRequestParameters parameters = null);
        Task<T> GetNoteAsync(string zoneName, int noteID);
    }
}
