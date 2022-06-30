using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using ANS.API.Client.Exception;
using ANS.API.Client.Models;
using ANS.API.Client.Request;
using ANS.API.Client.SafeDNS.Models;
using ANS.API.Client.SafeDNS.Models.Request;
using ANS.API.Client.SafeDNS.Operations;

namespace ANS.API.Client.SafeDNS.Tests.Operations
{
    [TestClass]
    public class ZoneOperationsTests
    {
        [TestMethod]
        public async Task CreateZoneAsync_ExpectedResult()
        {
            CreateZoneRequest req = new CreateZoneRequest()
            {
                Name = "example.com"
            };

            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();
            client.PostAsync<Zone>("/safedns/v1/zones", req).Returns(new Zone()
            {
                Name = "example.com"
            });

            var ops = new ZoneOperations<Zone>(client);
            string name = await ops.CreateZoneAsync(req);

            Assert.AreEqual("example.com", name);
        }

        [TestMethod]
        public async Task GetZonesAsync_ExpectedResult()
        {
            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();
            var ops = new ZoneOperations<Zone>(client);

            client.GetAllAsync(Arg.Any<ANSClient.GetPaginatedAsyncFunc<Zone>>(), null).Returns(Task.Run<IList<Zone>>(() =>
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
            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();
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

            var ops = new ZoneOperations<Zone>(client);
            var paginated = await ops.GetZonesPaginatedAsync();

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetZoneAsync_ValidParameters_ExpectedResult()
        {
            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();
            client.GetAsync<Zone>("/safedns/v1/zones/example.com").Returns(new Zone()
            {
                Name = "example.com"
            });

            var ops = new ZoneOperations<Zone>(client);
            var zone = await ops.GetZoneAsync("example.com");

            Assert.AreEqual("example.com", zone.Name);
        }

        [TestMethod]
        public async Task GetZoneAsync_InvalidZoneName_ThrowsANSClientValidationException()
        {
            var ops = new ZoneOperations<Zone>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.GetZoneAsync(""));
        }

        [TestMethod]
        public async Task UpdateZoneAsync_ValidParameters_ExpectedClientCall()
        {
            UpdateZoneRequest req = new UpdateZoneRequest()
            {
                Description = "test description 1"
            };

            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();

            var ops = new ZoneOperations<Zone>(client);
            await ops.UpdateZoneAsync("example.com", req);

            await client.Received().PatchAsync("/safedns/v1/zones/example.com", req);
        }

        [TestMethod]
        public async Task UpdateZoneAsync_InvalidZoneName_ThrowsANSClientValidationException()
        {
            var ops = new ZoneOperations<Zone>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.UpdateZoneAsync("", null));
        }

        [TestMethod]
        public async Task DeleteZoneAsync_ValidParameters_ExpectedClientCall()
        {
            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();

            var ops = new ZoneOperations<Zone>(client);
            await ops.DeleteZoneAsync("example.com");

            await client.Received().DeleteAsync("/safedns/v1/zones/example.com");
        }

        [TestMethod]
        public async Task DeleteZoneAsync_InvalidZoneName_ThrowsANSClientValidationException()
        {
            var ops = new ZoneOperations<Zone>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.DeleteZoneAsync(""));
        }
    }
}
