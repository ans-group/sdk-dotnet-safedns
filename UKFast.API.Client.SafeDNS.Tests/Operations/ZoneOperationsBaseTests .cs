using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;
using UKFast.API.Client.SafeDNS.Models;
using UKFast.API.Client.SafeDNS.Models.Request;
using UKFast.API.Client.SafeDNS.Operations;

namespace UKFast.API.Client.SafeDNS.Tests.Operations
{
    [TestClass]
    public class ZoneOperationsBaseTests
    {
        [TestMethod]
        public async Task CreateZoneAsync_ExpectedResult()
        {
            CreateZoneRequest req = new CreateZoneRequest()
            {
                Name = "example.com"
            };

            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            client.PostAsync<Zone>("/safedns/v1/zones", req).Returns(new Zone()
            {
                Name = "example.com"
            });

            ZoneOperations ops = new ZoneOperations(client);
            string name = await ops.CreateZoneAsync(req);

            Assert.AreEqual("example.com", name);
        }

        [TestMethod]
        public async Task GetZonesAsync_ExpectedResult()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            ZoneOperations ops = new ZoneOperations(client);

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<Zone>>(), null).Returns(Task.Run<IList<Zone>>(() =>
             {
                 return new List<Zone>()
                 {
                        new Zone(),
                        new Zone()
                 };
             }));

            var zones = await ops.GetZonesAsync();

            Assert.AreEqual(2, zones.Count);
        }

        [TestMethod]
        public async Task GetZonesPaginatedAsync_ExpectedClientCall()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            client.GetPaginatedAsync<Zone>("/safedns/v1/zones").Returns(Task.Run(() =>
            {
                return new Paginated<Zone>(client, "/safedns/v1/zones", null, new Response.ClientResponse<System.Collections.Generic.IList<Zone>>()
                {
                    Body = new Response.ClientResponseBody<System.Collections.Generic.IList<Zone>>()
                    {
                        Data = new List<Zone>()
                        {
                            new Zone(),
                            new Zone()
                        }
                    }
                });
            }));

            ZoneOperations ops = new ZoneOperations(client);
            var paginated = await ops.GetZonesPaginatedAsync();

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetZoneAsync_ValidParameters_ExpectedResult()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            client.GetAsync<Zone>("/safedns/v1/zones/example.com").Returns(new Zone()
            {
                Name = "example.com"
            });

            ZoneOperations ops = new ZoneOperations(client);
            var zone = await ops.GetZoneAsync("example.com");

            Assert.AreEqual("example.com", zone.Name);
        }

        [TestMethod]
        public async Task GetZoneAsync_InvalidZoneName_ThrowsUKFastClientValidationException()
        {
            ZoneOperations ops = new ZoneOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetZoneAsync(""));
        }

        [TestMethod]
        public async Task UpdateZoneAsync_ValidParameters_ExpectedClientCall()
        {
            UpdateZoneRequest req = new UpdateZoneRequest()
            {
                Description = "test description 1"
            };

            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            await client.PatchAsync("/safedns/v1/zones/example.com", req);

            ZoneOperations ops = new ZoneOperations(client);
            await ops.UpdateZoneAsync("example.com", req);

            await client.Received().PatchAsync("/safedns/v1/zones/example.com", req);
        }

        [TestMethod]
        public async Task UpdateZoneAsync_InvalidZoneName_ThrowsUKFastClientValidationException()
        {
            ZoneOperations ops = new ZoneOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.UpdateZoneAsync("", null));
        }

        [TestMethod]
        public async Task DeleteZoneAsync_ValidParameters_ExpectedClientCall()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            await client.DeleteAsync("/safedns/v1/zones/example.com");

            ZoneOperations ops = new ZoneOperations(client);
            await ops.DeleteZoneAsync("example.com");

            await client.Received().DeleteAsync("/safedns/v1/zones/example.com");
        }

        [TestMethod]
        public async Task DeleteZoneAsync_InvalidZoneName_ThrowsUKFastClientValidationException()
        {
            ZoneOperations ops = new ZoneOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.DeleteZoneAsync(""));
        }
    }
}
