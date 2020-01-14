# Azure Identity Extensions

This repo is a place for us to share ideas and extensions to the Azure Identity libraries.

> WARNING: Nothing in this repo or related package managers is intended for production use.  The included code and packages are just stopgaps until they are implemented in the [official Azure SDKs](https://aka.ms/sdkdocs).

> ADDITIONAL WARNING: This hasn't been fully tested, so use at your own risk.  You are likely better off copying the code into your own project versus using via package managers.

## DefaultAzureMgmtCredential

### .NET
The `DefaultAzureMgmtCredential` class allows you to use all the goodness of `Azure.Identity.DefaultAzureCredential` in the Azure Management libraries. You can use it in place of `ServiceClientCredential` when calling your Azure Management APIs. The Azure Management libraries will be updated to support Azure Identity and Azure Core in early 2020, so this should just be used a a stopgap between now and then.

Example usage:


### Application Insights

```
dotnet add package JonGallant.Azure.Identity.Extensions
dotnet add package Microsoft.Azure.Management.ApplicationInsights --version 0.2.0-preview
```

Use DefaultAzureMgmtCredential in place of ServiceClientCredential:
```csharp
using JonGallant.Azure.Identity.Extensions;
using Microsoft.Azure.Management.ApplicationInsights.Management;

var appInsightsClient = new ApplicationInsightsManagementClient(new DefaultAzureMgmtCredential());
```


### CosmosDB

```
dotnet add package JonGallant.Azure.Identity.Extensions
dotnet add package Microsoft.Azure.Management.CosmosDB --version 1.0.1
```

Use DefaultAzureMgmtCredential in place of ServiceClientCredential:
```csharp
using JonGallant.Azure.Identity.Extensions;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;

var client = new CosmosDBManagementClient(new DefaultAzureMgmtCredential());
```

More to come soon.  Please file a GitHub issue with any questions/suggestions.