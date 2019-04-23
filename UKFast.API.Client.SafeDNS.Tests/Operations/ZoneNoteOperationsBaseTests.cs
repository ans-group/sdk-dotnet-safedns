using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.SafeDNS.Models;
using UKFast.API.Client.SafeDNS.Models.Request;
using UKFast.API.Client.SafeDNS.Operations;

namespace UKFast.API.Client.SafeDNS.Tests.Operations
{
    [TestClass]
    public class ZoneNoteOperationsBaseTests
    {
        [TestMethod]
        public async Task CreateZoneNoteAsync_ExpectedResult()
        {
            CreateNoteRequest req = new CreateNoteRequest()
            {
                Notes = "test note"
            };

            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            client.PostAsync<Note>("/safedns/v1/zones/example.com/notes", req).Returns(new Note()
            {
                ID = 123
            });

            ZoneNoteOperations ops = new ZoneNoteOperations(client);
            int id = await ops.CreateNoteAsync("example.com", req);

            Assert.AreEqual(123, id);
        }

        [TestMethod]
        public async Task CreateZoneNoteAsync_InvalidTemplateID_ThrowsUKFastClientValidationException()
        {
            ZoneNoteOperations ops = new ZoneNoteOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.CreateNoteAsync("", null));
        }



        [TestMethod]
        public async Task GetZoneNotesAsync_ExpectedResult()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            ZoneNoteOperations ops = new ZoneNoteOperations(client);

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<Note>>(), null).Returns(Task.Run<IList<Note>>(() =>
            {
                return new List<Note>()
                {
                    new Note(),
                    new Note()
                };
            }));

            var notes = await ops.GetNotesAsync("example.com");

            Assert.AreEqual(2, notes.Count);
        }

        [TestMethod]
        public async Task GetZoneNotesPaginatedAsync_ExpectedClientCall()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            client.GetPaginatedAsync<Note>("/safedns/v1/zones/example.com/notes").Returns(Task.Run(() =>
            {
                return new Paginated<Note>(client, "/safedns/v1/zones/example.com/notes", null, new Response.ClientResponse<System.Collections.Generic.IList<Note>>()
                {
                    Body = new Response.ClientResponseBody<System.Collections.Generic.IList<Note>>()
                    {
                        Data = new List<Note>()
                        {
                            new Note(),
                            new Note()
                        }
                    }
                });
            }));

            ZoneNoteOperations ops = new ZoneNoteOperations(client);
            var paginated = await ops.GetNotesPaginatedAsync("example.com");

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetZoneNotesPaginatedAsync_InvalidTemplateID_ThrowsUKFastClientValidationException()
        {
            ZoneNoteOperations ops = new ZoneNoteOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetNotesPaginatedAsync(""));
        }

        [TestMethod]
        public async Task GetZoneNoteAsync_ValidParameters_ExpectedResult()
        {
            IUKFastSafeDNSClient client = Substitute.For<IUKFastSafeDNSClient>();
            client.GetAsync<Note>("/safedns/v1/zones/example.com/notes/123").Returns(new Note()
            {
                ID = 123
            });

            ZoneNoteOperations ops = new ZoneNoteOperations(client);
            var note = await ops.GetNoteAsync("example.com", 123);

            Assert.AreEqual(123, note.ID);
        }

        [TestMethod]
        public async Task GetZoneNoteAsync_InvalidZoneName_ThrowsUKFastClientValidationException()
        {
            ZoneNoteOperations ops = new ZoneNoteOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetNoteAsync("", 123));
        }

        [TestMethod]
        public async Task GetZoneNoteAsync_InvalidNoteID_ThrowsUKFastClientValidationException()
        {
            ZoneNoteOperations ops = new ZoneNoteOperations(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetNoteAsync("example.com", 0));
        }
    }
}
