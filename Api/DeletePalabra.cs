using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.CosmosDB;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;

namespace PalabrasApp.Api
{
    public static class DeletePalabra
    {
        [FunctionName("DeletePalabra")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(
                authLevel: AuthorizationLevel.Anonymous,
                methods: "delete",
                Route = "/{id}")] HttpRequest request,
            [CosmosDB(
                databaseName: "palabras",
                collectionName: "ContainerMain")] DocumentClient client,
            Guid id)
        {
            Uri palabraUri = UriFactory.CreateDocumentUri("palabras", "ContainerMain", id.ToString());
            PartitionKey partitionKey = new PartitionKey("/Words");
            RequestOptions requestOptions = new RequestOptions { PartitionKey = partitionKey };

            ResourceResponse<Document> response = await client.DeleteDocumentAsync(palabraUri, requestOptions);
            // Use response for something or not...

            return new NoContentResult();
        }
    }
}
