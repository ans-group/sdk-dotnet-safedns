using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
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
    public class ZoneRecordOperationsTests
    {
        [TestMethod]
        public async Task CreateZoneRecordAsync_ExpectedResult()
        {
            CreateRecordRequest req = new CreateRecordRequest()
            {
                Name = "test.example.com"
            };

            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            client.PostAsync<Record>("/safedns/v1/zones/example.com/records", Arg.Is<CreateRecordRequest>(x => x.Name == "test.example.com")).Returns(new Record()
            {
                ID = 123
            });

            var ops = new ZoneRecordOperations<Record>(client);
            int id = await ops.CreateRecordAsync("example.com", req);

            Assert.AreEqual(123, id);
        }

        [TestMethod]
        public async Task CreateZoneRecordAsync_InvalidZoneID_ThrowsUKFastClientValidationException()
        {
            var ops = new ZoneRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.CreateRecordAsync("", null));
        }

        [TestMethod]
        public async Task GetZoneRecordsAsync_ExpectedResult()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            var ops = new ZoneRecordOperations<Record>(client);

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<Record>>(), null).Returns(Task.Run<IList<Record>>(() =>
            {
                return new List<Record>()
                {
                    new Record(),
                    new Record()
                };
            }));

            var records = await ops.GetRecordsAsync("example.com");

            Assert.AreEqual(2, records.Count);
        }

        [TestMethod]
        public async Task GetZoneRecordsPaginatedAsync_ExpectedClientCall()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            client.GetPaginatedAsync<Record>("/safedns/v1/zones/example.com/records").Returns(Task.Run(() =>
            {
                return new Paginated<Record>(client, "/safedns/v1/zones/example.com/records", null, new Response.ClientResponse<System.Collections.Generic.IList<Record>>()
                {
                    Body = new Response.ClientResponseBody<System.Collections.Generic.IList<Record>>()
                    {
                        Data = new List<Record>()
                        {
                            new Record(),
                            new Record()
                        }
                    }
                });
            }));

            var ops = new ZoneRecordOperations<Record>(client);
            var paginated = await ops.GetRecordsPaginatedAsync("example.com");

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetZoneRecordsPaginatedAsync_InvalidZoneID_ThrowsUKFastClientValidationException()
        {
            var ops = new ZoneRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetRecordsPaginatedAsync(""));
        }

        [TestMethod]
        public async Task GetZoneRecordAsync_ValidParameters_ExpectedResult()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            client.GetAsync<Record>("/safedns/v1/zones/example.com/records/123").Returns(new Record()
            {
                ID = 123
            });

            var ops = new ZoneRecordOperations<Record>(client);
            var ZoneRecord = await ops.GetRecordAsync("example.com", 123);

            Assert.AreEqual(123, ZoneRecord.ID);
        }

        [TestMethod]
        public async Task GetZoneRecordAsync_InvalidZoneID_ThrowsUKFastClientValidationException()
        {
            var ops = new ZoneRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetRecordAsync("", 123));
        }

        [TestMethod]
        public async Task GetZoneRecordAsync_InvalidRecordID_ThrowsUKFastClientValidationException()
        {
            var ops = new ZoneRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetRecordAsync("example.com", 0));
        }

        [TestMethod]
        public async Task UpdateZoneRecordAsync_ValidParameters_ExpectedClientCall()
        {
            UpdateRecordRequest req = new UpdateRecordRequest()
            {
                Name = "new.example.com"
            };

            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            await client.PatchAsync("/safedns/v1/zones/example.com/records/123", req);

            var ops = new ZoneRecordOperations<Record>(client);
            await ops.UpdateRecordAsync("example.com", 123, req);

            await client.Received().PatchAsync("/safedns/v1/zones/example.com/records/123", req);
        }

        [TestMethod]
        public async Task UpdateZoneRecordAsync_InvalidZoneID_ThrowsUKFastClientValidationException()
        {
            var ops = new ZoneRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.UpdateRecordAsync("", 123, null));
        }

        [TestMethod]
        public async Task UpdateZoneRecordAsync_InvalidRecordID_ThrowsUKFastClientValidationException()
        {
            var ops = new ZoneRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.UpdateRecordAsync("example.com", 0, null));
        }

        [TestMethod]
        public async Task DeleteZoneRecordAsync_ValidParameters_ExpectedClientCall()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            await client.DeleteAsync("/safedns/v1/zones/example.com/records/123");

            var ops = new ZoneRecordOperations<Record>(client);
            await ops.DeleteRecordAsync("example.com", 123);

            await client.Received().DeleteAsync("/safedns/v1/zones/example.com/records/123");
        }

        [TestMethod]
        public async Task DeleteZoneRecordAsync_InvalidZoneID_ThrowsUKFastClientValidationException()
        {
            var ops = new ZoneRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.DeleteRecordAsync("", 123));
        }

        [TestMethod]
        public async Task DeleteZoneRecordAsync_InvalidRecordID_ThrowsUKFastClientValidationException()
        {
            var ops = new ZoneRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.DeleteRecordAsync("example.com", 0));
        }
    }
}
