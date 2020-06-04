using System;
using System.Threading.Tasks;
using UKFast.API.Client.SafeDNS.Models;

namespace UKFast.API.Client.SafeDNS.Operations
{
    public class SettingsOperations<T> : SafeDNSOperations, ISettingsOperations<T> where T : Settings
    {

        public SettingsOperations(IUKFastSafeDNSClient client) : base(client) { }

        public async Task<T> GetSettingsAsync()
        {
            return await Client.GetAsync<T>($"/safedns/v1/settings");
        }
    }
}