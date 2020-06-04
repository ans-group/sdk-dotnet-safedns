using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;
using UKFast.API.Client.SafeDNS.Models;
using UKFast.API.Client.SafeDNS.Operations;

namespace UKFast.API.Client.SafeDNS.Tests.Operations
{
    [TestClass]
    public class SettingsOperationsTests
    {
        [TestMethod]
        public async Task GetSettingsAsync_ExpectedResult()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
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