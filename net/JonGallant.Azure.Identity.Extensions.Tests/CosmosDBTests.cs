using DotNetEnv;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace JonGallant.Azure.Identity.Extensions.Tests
{
    public class CosmosDBTests
    {
        [Fact]
        public void CreateCosmosDBTest()
        {
            Env.Load("../../../.env");


            var client = new CosmosDBManagementClient(new DefaultAzureMgmtCredential());
            client.SubscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID");

            var name = Environment.GetEnvironmentVariable("COSMOSDB_NAME") + Guid.NewGuid().ToString("n").Substring(0, 8);

            var parameters = new DatabaseAccountCreateUpdateParameters
            {
                Location = Environment.GetEnvironmentVariable("AZURE_REGION"),
                Locations = new List<Location> { new Location(locationName: Environment.GetEnvironmentVariable("AZURE_REGION")) }
            };

            var results = client.DatabaseAccounts.CreateOrUpdate(Environment.GetEnvironmentVariable("AZURE_RESOURCE_GROUP"), name, parameters);

            Assert.Equal(results.Name, name);
        }
    }
}
