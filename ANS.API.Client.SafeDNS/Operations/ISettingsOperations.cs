using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ANS.API.Client.SafeDNS.Models;

namespace ANS.API.Client.SafeDNS.Operations
{
    public interface ISettingsOperations<T> where T : Settings
    {
        Task<T> GetSettingsAsync();
    }
}
