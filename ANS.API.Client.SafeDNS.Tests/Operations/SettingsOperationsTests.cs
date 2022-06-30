using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;
using ANS.API.Client.SafeDNS.Models;
using ANS.API.Client.SafeDNS.Operations;

namespace ANS.API.Client.SafeDNS.Tests.Operations
{
    [TestClass]
    public class SettingsOperationsTests
    {
        [TestMethod]
        public async Task GetSettingsAsync_ExpectedResult()
        {
            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();
            client.GetAsync<Settings>("/safedns/v1/settings").Returns(new Settings()
            {
                ID = 123
            });

            var ops = new SettingsOperations<Settings>(client);
            var settings = await ops.GetSettingsAsync();

            Assert.AreEqual(123, settings.ID);
        }
    }
}