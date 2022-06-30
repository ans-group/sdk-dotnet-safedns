using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ANS.API.Client.Exception;
using ANS.API.Client.Models;
using ANS.API.Client.SafeDNS.Models;
using ANS.API.Client.SafeDNS.Models.Request;
using ANS.API.Client.SafeDNS.Operations;

namespace ANS.API.Client.SafeDNS.Tests.Operations
{
    [TestClass]
    public class ZoneNoteOperationsTests
    {
        [TestMethod]
        public async Task CreateZoneNoteAsync_ExpectedResult()
        {
            CreateNoteRequest req = new CreateNoteRequest()
            {
                Notes = "test note"
            };

            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();
            client.PostAsync<Note>("/safedns/v1/zones/example.com/notes", req).Returns(new Note()
            {
                ID = 123
            });

            var ops = new ZoneNoteOperations<Note>(client);
            int id = await ops.CreateNoteAsync("example.com", req);

            Assert.AreEqual(123, id);
        }

        [TestMethod]
        public async Task CreateZoneNoteAsync_InvalidTemplateID_ThrowsANSClientValidationException()
        {
            var ops = new ZoneNoteOperations<Note>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.CreateNoteAsync("", null));
        }



        [TestMethod]
        public async Task GetZoneNotesAsync_ExpectedResult()
        {
            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();
            var ops = new ZoneNoteOperations<Note>(client);

            client.GetAllAsync(Arg.Any<ANSClient.GetPaginatedAsyncFunc<Note>>(), null).Returns(Task.Run<IList<Note>>(() =>
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
            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();
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

            var ops = new ZoneNoteOperations<Note>(client);
            var paginated = await ops.GetNotesPaginatedAsync("example.com");

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetZoneNotesPaginatedAsync_InvalidTemplateID_ThrowsANSClientValidationException()
        {
            var ops = new ZoneNoteOperations<Note>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.GetNotesPaginatedAsync(""));
        }

        [TestMethod]
        public async Task GetZoneNoteAsync_ValidParameters_ExpectedResult()
        {
            IANSSafeDNSClient client = Substitute.For<IANSSafeDNSClient>();
            client.GetAsync<Note>("/safedns/v1/zones/example.com/notes/123").Returns(new Note()
            {
                ID = 123
            });

            var ops = new ZoneNoteOperations<Note>(client);
            var note = await ops.GetNoteAsync("example.com", 123);

            Assert.AreEqual(123, note.ID);
        }

        [TestMethod]
        public async Task GetZoneNoteAsync_InvalidZoneName_ThrowsANSClientValidationException()
        {
            var ops = new ZoneNoteOperations<Note>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.GetNoteAsync("", 123));
        }

        [TestMethod]
        public async Task GetZoneNoteAsync_InvalidNoteID_ThrowsANSClientValidationException()
        {
            var ops = new ZoneNoteOperations<Note>(null);
            await Assert.ThrowsExceptionAsync<ANSClientValidationException>(() => ops.GetNoteAsync("example.com", 0));
        }
    }
}
