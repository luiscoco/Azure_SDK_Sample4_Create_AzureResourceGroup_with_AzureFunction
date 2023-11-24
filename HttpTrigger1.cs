using System.Net;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager;
using Azure;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class HttpTrigger1
    {
        private readonly ILogger _logger;

        public HttpTrigger1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpTrigger1>();
        }

        [Function("HttpTrigger1")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();

            string rgName = "myRgNameLCESEGUNDO";
            AzureLocation location = AzureLocation.WestEurope;
            ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = operation.Value;
            Console.WriteLine(resourceGroup.Data.Name);

            return response;
        }
    }
}
