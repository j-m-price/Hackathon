using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var client = new CosmosClient("AccountEndpoint=https://journey-db.documents.azure.com:443/;AccountKey=TJLjMS9a8VyZUfWUxYUxtVY0NklHijxYanuFGijQcjKzCz4CfcI9tScpuCIANsmGS6o81cTULIz2n1ETexak5w==;", null);
            this._container = client.GetContainer("journey-db", "journeys");
        }



        public async Task<bool> DeleteAsync(int journeyId)
        {
            // maybe have id as string??? 
            // so partitionKey takes a double... but id is a string...
            await this._container.DeleteItemAsync<Journey>(journeyId.ToString(), new PartitionKey(journeyId));
            return true;
        }

        public async Task<Journey> GetJourneyByProductAndIdAsync(string product, string id)
        {
            var sqlQueryText = $"SELECT * FROM c WHERE c.Product = '{product}' AND c.id = '{id}'";
            var journeys = await _ExecuteIteratorQuery(sqlQueryText);

            return journeys.FirstOrDefault();
        }

        public async Task<Journey> GetJourneyByProductAsync(string product)
        {
            var sqlQueryText = $"SELECT TOP 1 * FROM c WHERE c.Product = '{product}' ORDER BY c._ts DESC";
            var journeys = await _ExecuteIteratorQuery(sqlQueryText);

            return journeys.FirstOrDefault();
        }

        public async Task<bool> SaveAsync(Journey journey)
        {
            await this._container.CreateItemAsync<Journey>(journey, new PartitionKey(journey.Id));
            return true;
        }
        public async Task<Journey> SaveNewJourney(Journey journey)
        {
            //TODO - If exists checks + get partition key saving properly
            return await this._container.CreateItemAsync(journey);
        }

        public async Task<IEnumerable<Journey>> GetAsync()
        {
            var sqlQueryText = "SELECT * FROM c";
            var journeys = await _ExecuteIteratorQuery(sqlQueryText);

            return journeys;
        }

        private async Task<IEnumerable<Journey>> _ExecuteIteratorQuery(string sqlQueryText)
        {
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
