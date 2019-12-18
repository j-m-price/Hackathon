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

        public JourneyRepository(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task<bool> DeleteAsync(int journeyId)
        {
            // maybe have id as string??? 
            // so partitionKey takes a double... but id is a string...
            await this._container.DeleteItemAsync<Journey>(journeyId.ToString(), new PartitionKey(journeyId));
            return true;
        }

        public async Task<Journey> GetAsync()
        {
            // need to change to get latest active journey for the product
            var id = 0;
            try
            {
                // again, make id string??
                ItemResponse<Journey> response = await this._container.ReadItemAsync<Journey>(id.ToString(), new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            };
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

        Task<IEnumerable<Journey>> IJourneyRepository.GetAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
