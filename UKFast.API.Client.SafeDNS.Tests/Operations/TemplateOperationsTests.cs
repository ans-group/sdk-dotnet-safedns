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
    public class TemplateOperationsTests
    {
        [TestMethod]
        public async Task CreateTemplateAsync_ExpectedResult()
        {
            CreateTemplateRequest req = new CreateTemplateRequest()
            {
                Name = "testtemplate1"
            };

            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            client.PostAsync<Template>("/safedns/v1/templates", req).Returns(new Template()
            {
                ID = 123
            });

            var ops = new TemplateOperations<Template>(client);
            int id = await ops.CreateTemplateAsync(req);

            Assert.AreEqual(123, id);
        }

        [TestMethod]
        public async Task GetTemplatesAsync_ExpectedResult()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            var ops = new TemplateOperations<Template>(client);

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<Template>>(), null).Returns(Task.Run<IList<Template>>(() =>
             {
                 return new List<Template>()
                 {
                        new Template(),
                        new Template()
                 };
             }));

            var templates = await ops.GetTemplatesAsync();

            Assert.AreEqual(2, templates.Count);
        }

        [TestMethod]
        public async Task GetTemplatesPaginatedAsync_ExpectedClientCall()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            client.GetPaginatedAsync<Template>("/safedns/v1/templates").Returns(Task.Run(() =>
            {
                return new Paginated<Template>(client, "/safedns/v1/templates", null, new Response.ClientResponse<System.Collections.Generic.IList<Template>>()
                {
                    Body = new Response.ClientResponseBody<System.Collections.Generic.IList<Template>>()
                    {
                        Data = new List<Template>()
                        {
                            new Template(),
                            new Template()
                        }
                    }
                });
            }));

            var ops = new TemplateOperations<Template>(client);
            var paginated = await ops.GetTemplatesPaginatedAsync();

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetTemplateAsync_ValidParameters_ExpectedResult()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            client.GetAsync<Template>("/safedns/v1/templates/123").Returns(new Template()
            {
                ID = 123
            });

            var ops = new TemplateOperations<Template>(client);
            var template = await ops.GetTemplateAsync(123);

            Assert.AreEqual(123, template.ID);
        }

        [TestMethod]
        public async Task GetTemplateAsync_InvalidTemplateID_ThrowsUKFastClientValidationException()
        {
            var ops = new TemplateOperations<Template>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetTemplateAsync(0));
        }

        [TestMethod]
        public async Task UpdateTemplateAsync_ValidParameters_ExpectedClientCall()
        {
            UpdateTemplateRequest req = new UpdateTemplateRequest()
            {
                Name = "template1"
            };

            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            await client.PatchAsync("/safedns/v1/templates/123", req);

            var ops = new TemplateOperations<Template>(client);
            await ops.UpdateTemplateAsync(123, req);

            await client.Received().PatchAsync("/safedns/v1/templates/123", req);
        }

        [TestMethod]
        public async Task UpdateTemplateAsync_InvalidTemplateID_ThrowsUKFastClientValidationException()
        {
            var ops = new TemplateOperations<Template>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.UpdateTemplateAsync(0, null));
        }

        [TestMethod]
        public async Task DeleteTemplateAsync_ValidParameters_ExpectedClientCall()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            await client.DeleteAsync("/safedns/v1/templates/123");

            var ops = new TemplateOperations<Template>(client);
            await ops.DeleteTemplateAsync(123);

            await client.Received().DeleteAsync("/safedns/v1/templates/123");
        }

        [TestMethod]
        public async Task DeleteTemplateAsync_InvalidTemplateID_ThrowsUKFastClientValidationException()
        {
            var ops = new TemplateOperations<Template>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.DeleteTemplateAsync(0));
        }
    }
}
