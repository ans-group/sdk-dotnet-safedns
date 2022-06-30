using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
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
    public class TemplateRecordOperationsTests
    {
        [TestMethod]
        public async Task CreateTemplateRecordAsync_ExpectedResult()
        {
            CreateRecordRequest req = new CreateRecordRequest()
            {
                Name = "test.example.com"
            };

            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();
            client.PostAsync<Record>("/safedns/v1/templates/123/records", req).Returns(new Record()
            {
                ID = 123
            });

            var ops = new TemplateRecordOperations<Record>(client);
            int id = await ops.CreateRecordAsync(123, req);

            Assert.AreEqual(123, id);
        }

        [TestMethod]
        public async Task CreateTemplateRecordAsync_InvalidTemplateID_ThrowsANSClientValidationException()
        {
            var ops = new TemplateRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.CreateRecordAsync(0, null));
        }

        [TestMethod]
        public async Task GetTemplateRecordsAsync_ExpectedResult()
        {
            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();
            var ops = new TemplateRecordOperations<Record>(client);

            client.GetAllAsync(Arg.Any<ANSClient.GetPaginatedAsyncFunc<Record>>(), null).Returns(Task.Run<IList<Record>>(() =>
            {
                return new List<Record>()
                {
                    new Record(),
                    new Record()
                };
            }));

            var records = await ops.GetRecordsAsync(123);

            Assert.AreEqual(2, records.Count);
        }

        [TestMethod]
        public async Task GetTemplateRecordsPaginatedAsync_ExpectedClientCall()
        {
            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();
            client.GetPaginatedAsync<Record>("/safedns/v1/templates/123/records").Returns(Task.Run(() =>
            {
                return new Paginated<Record>(client, "/safedns/v1/templates/123/records", null, new Response.ClientResponse<System.Collections.Generic.IList<Record>>()
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

            var ops = new TemplateRecordOperations<Record>(client);
            var paginated = await ops.GetRecordsPaginatedAsync(123);

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetTemplateRecordsPaginatedAsync_InvalidTemplateID_ThrowsANSClientValidationException()
        {
            var ops = new TemplateRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.GetRecordsPaginatedAsync(0));
        }

        [TestMethod]
        public async Task GetTemplateRecordAsync_ValidParameters_ExpectedResult()
        {
            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();
            client.GetAsync<Record>("/safedns/v1/templates/123/records/456").Returns(new Record()
            {
                ID = 123
            });

            var ops = new TemplateRecordOperations<Record>(client);
            var TemplateRecord = await ops.GetRecordAsync(123, 456);

            Assert.AreEqual(123, TemplateRecord.ID);
        }

        [TestMethod]
        public async Task GetTemplateRecordAsync_InvalidTemplateID_ThrowsANSClientValidationException()
        {
            var ops = new TemplateRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.GetRecordAsync(0, 456));
        }

        [TestMethod]
        public async Task GetTemplateRecordAsync_InvalidRecordID_ThrowsANSClientValidationException()
        {
            var ops = new TemplateRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.GetRecordAsync(123, 0));
        }

        [TestMethod]
        public async Task UpdateTemplateRecordAsync_ValidParameters_ExpectedClientCall()
        {
            UpdateRecordRequest req = new UpdateRecordRequest()
            {
                Name = "new.example.com"
            };

            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();

            var ops = new TemplateRecordOperations<Record>(client);
            await ops.UpdateRecordAsync(123, 456, req);

            await client.Received().PatchAsync("/safedns/v1/templates/123/records/456", req);
        }

        [TestMethod]
        public async Task UpdateTemplateRecordAsync_InvalidTemplateID_ThrowsANSClientValidationException()
        {
            var ops = new TemplateRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.UpdateRecordAsync(0, 456, null));
        }

        [TestMethod]
        public async Task UpdateTemplateRecordAsync_InvalidRecordID_ThrowsANSClientValidationException()
        {
            var ops = new TemplateRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.UpdateRecordAsync(123, 0, null));
        }

        [TestMethod]
        public async Task DeleteTemplateRecordAsync_ValidParameters_ExpectedClientCall()
        {
            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();

            var ops = new TemplateRecordOperations<Record>(client);
            await ops.DeleteRecordAsync(123, 456);

            await client.Received().DeleteAsync("/safedns/v1/templates/123/records/456");
        }

        [TestMethod]
        public async Task DeleteTemplateRecordAsync_InvalidTemplateID_ThrowsANSClientValidationException()
        {
            var ops = new TemplateRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.DeleteRecordAsync(0, 456));
        }

        [TestMethod]
        public async Task DeleteTemplateRecordAsync_InvalidRecordID_ThrowsANSClientValidationException()
        {
            var ops = new TemplateRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.DeleteRecordAsync(123, 0));
        }
    }
}
