using System;
using System.Threading.Tasks;
using ANS.API.Client.SafeDNS.Models;

namespace ANS.API.Client.SafeDNS.Operations
{
    public class SettingsOperations<T> : SafeDNSOperations, ISettingsOperations<T> where T : Settings
    {

        public SettingsOperations(IANSSafeDNSClient client) : base(client) { }

        public async Task<T> GetSettingsAsync()
        {
            return await Client.GetAsync<T>($"/safedns/v1/settings");
        }
    }
}