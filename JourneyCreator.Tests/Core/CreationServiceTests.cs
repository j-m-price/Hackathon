using System;
using System.Linq;
using System.Threading.Tasks;
using JourneyCreator.Core.Models;
using JourneyCreator.Core.Services;
using Newtonsoft.Json;
using Xunit;

namespace JourneyCreator.Tests.Core
{
    public class CreationServiceTests
    {
        [Fact]
        public async Task MappingTest()
        {
            var mockData = "{\r\n    \"id\": 1,\r\n    \"publisher\": \"James Price\",\r\n    \"productId\": 6,\r\n    \"pages\": [\r\n       {\r\n          \"title\": \"Your Pet\",\r\n          \"questions\": [\r\n             {\r\n                \"id\": 0,\r\n                \"name\": \"pet-type\",\r\n                \"type\": \"GcSelect\",\r\n                \"label\": \"What type of animal is your pet?\",\r\n                \"required\": true,\r\n                \"options\": [\r\n                   {\r\n                      \"id\": 1,\r\n                      \"value\": \"Dog\"\r\n                   },\r\n                   {\r\n                      \"id\": 2,\r\n                      \"value\": \"Cat\"\r\n                   }\r\n                ],\r\n                \"default\": null\r\n             }\r\n          ]\r\n       },\r\n       {\r\n          \"title\": \"Your Cover\",\r\n          \"questions\": [\r\n             {\r\n                \"id\": 2,\r\n                \"name\": \"cover-type\",\r\n                \"type\": \"GcSelect\",\r\n                \"label\": \"Are you looking for help paying vet bills if your pet has accidents only or accidents and illness?\",\r\n                \"required\": true,\r\n                \"options\": [\r\n                   {\r\n                      \"id\": 1,\r\n                      \"value\": \"Accident Only\"\r\n                   },\r\n                   {\r\n                      \"id\": 2,\r\n                      \"value\": \"Accident and Illness\"\r\n                   }\r\n                ],\r\n                \"default\": null\r\n             }\r\n          ]\r\n       }\r\n    ]\r\n }";

            var journey = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Journey>(mockData));

            Assert.True(journey.Id == 1);
            Assert.True(journey.Publisher == "James Price");
            Assert.True(journey.ProductId == 6);
            Assert.True(journey.Pages.Count() == 2);
            Assert.True(journey.Pages.First().Title == "Your Pet");
            Assert.True(journey.Pages.First().Questions.First().Options.First().Value == "Dog");
            Assert.True(journey.Pages.Last().Title == "Your Cover");
        }

        [Fact]
        // Todo: add valid / invalid test scenarios
        public async Task CreateAsync_ReturnsTrue_WhenValidJourney_AndReturnsFalse_WhenInvalidJourney()
        {
            var sut = new CreationService();

            // configure await false, means that the test won't try and go back to the
            // same thread that called it. It will just assign a free thread.
            // var isValid = await sut.ValidateAsync().ConfigureAwait(false);

            await Assert.ThrowsAsync<NotImplementedException>(async () => await sut.CreateAsync());
        }

        [Fact]
        // Todo: add valid / invalid test scenarios
        public async Task DeleteAsync_ReturnsTrue_WhenJourneyIdExists_AndReturnsFalse_WhenJourneyIdDoesNotExist()
        {
            var sut = new CreationService();

            // configure await false, means that the test won't try and go back to the
            // same thread that called it. It will just assign a free thread.
            // var isValid = await sut.DeleteAsync().ConfigureAwait(false);

            await Assert.ThrowsAsync<NotImplementedException>(async () => await sut.DeleteAsync());
        }

        [Fact]
        // Todo: add valid / invalid test scenarios
        public async Task ActivateAsync_ReturnsTrue_WhenJourneyIdExists_AndReturnsFalse_WhenJourneyIdDoesNotExist_OrError()
        {
            var sut = new CreationService();

            // configure await false, means that the test won't try and go back to the
            // same thread that called it. It will just assign a free thread.
            // var isValid = await sut.ActivateAsync().ConfigureAwait(false);

            await Assert.ThrowsAsync<NotImplementedException>(async () => await sut.ActivateAsync());
        }

        [Fact]
        public async Task DeactivateAsync_ReturnsTrue_WhenJourneyIdExists_AndReturnsFalse_WhenJourneyIdDoesNotExist_OrError()
        {
            var sut = new CreationService();

            // configure await false, means that the test won't try and go back to the
            // same thread that called it. It will just assign a free thread.
            // var isValid = await sut.DeactivateAsync().ConfigureAwait(false);

            await Assert.ThrowsAsync<NotImplementedException>(async () => await sut.DeactivateAsync());
        }
    }
}
