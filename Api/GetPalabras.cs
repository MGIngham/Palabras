using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using PalabrasApp.Shared;

namespace PalabrasApp.Api
{
    public static class GetPalabras
    {
        [FunctionName("GetPalabras")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
                [CosmosDB(
                databaseName: "palabras",
                collectionName: "ContainerMain",
                SqlQuery = "SELECT * FROM ContainerMain",
                ConnectionStringSetting = "PalabrasConnectionString")]
                IEnumerable<Palabra> item,
            ILogger log)
        {
            return new OkObjectResult(item);
        }
    }
}
