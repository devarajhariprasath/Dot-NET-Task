using Dot_NET_Task.Models;
using Dot_NET_Task.Repository.IRepository;
using Microsoft.Azure.Cosmos;
using System.Net;

namespace Dot_NET_Task.Repository
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly CosmosClient cosmosClient;
        private readonly IConfiguration configuration;
        private readonly Container _taskContainer;
        public EmployerRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            this.cosmosClient = cosmosClient;
            this.configuration = configuration;
            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            var taskContainer = "Tasks";
            _taskContainer = cosmosClient.GetContainer(databaseName, taskContainer);
        }

        public async Task AddApplicationAsync(Application application)
        {
            await _taskContainer.CreateItemAsync(application, new PartitionKey(application.FormId));
        }

        public async Task AddFormAsync(Form form)
        {
            await _taskContainer.CreateItemAsync(form, new PartitionKey(form.EmployerId));
        }

        public async Task<Application> GetApplicationAsync(string id)
        {
            try
            {
                ItemResponse<Application> response = await _taskContainer.ReadItemAsync<Application>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Application>> GetApplicationsByFormIdAsync(string formId)
        {
            var query = _taskContainer.GetItemQueryIterator<Application>(new QueryDefinition("SELECT * FROM c WHERE c.FormId = @FormId").WithParameter("@FormId", formId));
            List<Application> results = new List<Application>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<Form> GetFormAsync(string id)
        {
            try
            {
                ItemResponse<Form> response = await _taskContainer.ReadItemAsync<Form>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task UpdateFormAsync(Form form)
        {
            await _taskContainer.UpsertItemAsync(form, new PartitionKey(form.EmployerId));
        }
    }
}
