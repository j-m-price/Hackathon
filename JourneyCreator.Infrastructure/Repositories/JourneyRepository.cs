using System.Collections.Generic;
using System.Threading.Tasks;
using JourneyCreator.Core.Interfaces;
using JourneyCreator.Core.Models;
using Microsoft.Azure.Cosmos;

namespace JourneyCreator.Infrastructure.Repositories
{
    public class JourneyRepository : IJourneyRepository
    {
        private Container _container;

        public JourneyRepository()
        {
            var client = new CosmosClient("AccountEndpoint=https://dynamic-journey.documents.azure.com:443/;AccountKey=XCDk51XzPornsqfErlDRpkReuu7IY22ATj4o16xW7SMrWdCrky2OkhM2JhRVGQiCp3wCSkgkolE2gqdTX0f0Dw==;", null);
            this._container = client.GetContainer("journey", "journeycontainer");
        }



        public async Task<bool> DeleteAsync(int journeyId)
        {
            // maybe have id as string??? 
            // so partitionKey takes a double... but id is a string...
            await this._container.DeleteItemAsync<Journey>(journeyId.ToString(), new PartitionKey(journeyId));
            return true;
        }

        public async Task<Journey> GetByIdAsync(int journeyId)
        {
            try
            {
                // need to update to get journey for specific product.
                // again, make id string??
                ItemResponse<Journey> response = await this._container.ReadItemAsync<Journey>(journeyId.ToString(), new PartitionKey(journeyId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            };
        }

        public Task<Journey> GetJourneyByProductAndIdAsync(string product, int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Journey> GetJourneyByProductAsync(string product)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SaveAsync(Journey journey)
        {
            await this._container.CreateItemAsync<Journey>(journey, new PartitionKey(journey.Id));
            return true;
        }

        public Task<bool> SaveNewJourney(Journey journey)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Journey>> GetAsync()
        {
            var sqlQueryText = "SELECT * FROM c";
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<Journey> queryResultSetIterator = this._container.GetItemQueryIterator<Journey>(queryDefinition);
            List<Journey> journeys = new List<Journey>();
            while (queryResultSetIterator.HasMoreResults)
            {
                Microsoft.Azure.Cosmos.FeedResponse<Journey> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Journey journey in currentResultSet)
                {
                    journeys.Add(journey);
                }
            }
            return journeys;
        }
    }
}
