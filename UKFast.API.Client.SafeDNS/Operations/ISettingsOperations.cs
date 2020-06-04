using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UKFast.API.Client.SafeDNS.Models;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public interface ISettingsOperations<T> where T : Settings
    {
        Task<T> GetSettingsAsync();
    }
}
