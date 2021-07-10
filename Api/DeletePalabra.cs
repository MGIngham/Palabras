using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using PalabrasApp.Shared;


namespace PalabrasApp.Api
{
    public class DeletePalabra
    {
        private readonly CosmosClient _CosmosClient;

        public DeletePalabra(CosmosClient cosmosClient)
        {
            _CosmosClient = cosmosClient;
        }

        [FunctionName("DeletePalabra")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, 
            "delete", 
            Route = "DeletePalabra/{id}")] HttpRequest req,
            string id)
        {

            try
            {
                var container = _CosmosClient.GetContainer("palabras", "ContainerMain");

                var properties = await container.ReadContainerAsync();
                Console.WriteLine(properties.Container.ToString());

                await container.DeleteItemAsync<Palabra>(id, new PartitionKey("Palabra"));
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}