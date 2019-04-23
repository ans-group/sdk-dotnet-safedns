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
    public class TemplateRecordOperationsBaseTests
    {
        [TestMethod]
        public async Task CreateTemplateRecordAsync_ExpectedResult()
        {
            CreateRecordRequest req = new CreateRecordRequest()
            {
                Name = "test.example.com"
            };

            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            client.PostAsync<Record>("/safedns/v1/templates/123/records", req).Returns(new Record()
            {
                ID = 123
            });

            TemplateRecordOperations ops = new TemplateRecordOperations(client);
            int id = await ops.CreateRecordAsync(123, req);

            Assert.AreEqual(123, id);
        }

        [TestMethod]
        public async Task CreateTemplateRecordAsync_InvalidTemplateID_ThrowsUKFastClientValidationException()
        {
            TemplateRecordOperations ops = new TemplateRecordOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.CreateRecordAsync(0, null));
        }

        [TestMethod]
        public async Task GetTemplateRecordsAsync_ExpectedResult()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            TemplateRecordOperations ops = new TemplateRecordOperations(client);

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<Record>>(), null).Returns(Task.Run<IList<Record>>(() =>
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
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
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

            TemplateRecordOperations ops = new TemplateRecordOperations(client);
            var paginated = await ops.GetRecordsPaginatedAsync(123);

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetTemplateRecordsPaginatedAsync_InvalidTemplateID_ThrowsUKFastClientValidationException()
        {
            TemplateRecordOperations ops = new TemplateRecordOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetRecordsPaginatedAsync(0));
        }

        [TestMethod]
        public async Task GetTemplateRecordAsync_ValidParameters_ExpectedResult()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            client.GetAsync<Record>("/safedns/v1/templates/123/records/456").Returns(new Record()
            {
                ID = 123
            });

            TemplateRecordOperations ops = new TemplateRecordOperations(client);
            var TemplateRecord = await ops.GetRecordAsync(123, 456);

            Assert.AreEqual(123, TemplateRecord.ID);
        }

        [TestMethod]
        public async Task GetTemplateRecordAsync_InvalidTemplateID_ThrowsUKFastClientValidationException()
        {
            TemplateRecordOperations ops = new TemplateRecordOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetRecordAsync(0, 456));
        }

        [TestMethod]
        public async Task GetTemplateRecordAsync_InvalidRecordID_ThrowsUKFastClientValidationException()
        {
            TemplateRecordOperations ops = new TemplateRecordOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetRecordAsync(123, 0));
        }

        [TestMethod]
        public async Task UpdateTemplateRecordAsync_ValidParameters_ExpectedClientCall()
        {
            UpdateRecordRequest req = new UpdateRecordRequest()
            {
                Name = "new.example.com"
            };

            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            await client.PatchAsync("/safedns/v1/templates/123/records/456", req);

            TemplateRecordOperations ops = new TemplateRecordOperations(client);
            await ops.UpdateRecordAsync(123, 456, req);

            await client.Received().PatchAsync("/safedns/v1/templates/123/records/456", req);
        }

        [TestMethod]
        public async Task UpdateTemplateRecordAsync_InvalidTemplateID_ThrowsUKFastClientValidationException()
        {
            TemplateRecordOperations ops = new TemplateRecordOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.UpdateRecordAsync(0, 456, null));
        }

        [TestMethod]
        public async Task UpdateTemplateRecordAsync_InvalidRecordID_ThrowsUKFastClientValidationException()
        {
            TemplateRecordOperations ops = new TemplateRecordOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.UpdateRecordAsync(123, 0, null));
        }

        [TestMethod]
        public async Task DeleteTemplateRecordAsync_ValidParameters_ExpectedClientCall()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            await client.DeleteAsync("/safedns/v1/templates/123/records/456");

            TemplateRecordOperations ops = new TemplateRecordOperations(client);
            await ops.DeleteRecordAsync(123, 456);

            await client.Received().DeleteAsync("/safedns/v1/templates/123/records/456");
        }

        [TestMethod]
        public async Task DeleteTemplateRecordAsync_InvalidTemplateID_ThrowsUKFastClientValidationException()
        {
            TemplateRecordOperations ops = new TemplateRecordOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.DeleteRecordAsync(0, 456));
        }

        [TestMethod]
        public async Task DeleteTemplateRecordAsync_InvalidRecordID_ThrowsUKFastClientValidationException()
        {
            TemplateRecordOperations ops = new TemplateRecordOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.DeleteRecordAsync(123, 0));
        }
    }
}
