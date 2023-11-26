# How to create an Azure ResourceGroup from an  Azure Function (HttpTriggered)

## 1. Run VSCode and install the extensions

First we have to install "Azure Tools" extension.

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/f6940c98-fcdd-4933-885d-f4465a2acf18)

Then we install the "Azure Functions" extension.

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/c6fbbd9a-a084-44c7-ba9c-b3ceab517f8a)

## 2. Create a new Azure Function with VSCode

Click on the "Azure Tools" extension icon in the left menu.

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/fca0198a-9795-4135-936a-7533392f8b56)

Select the "**Create Function...**" option in the menu

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/cda0af8c-4c0c-4f2d-bbb7-dd8052a02da2)

Select the folder "/Azure Function/sample1/" where to place the new Azure Function:

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/8444ab5b-5fe2-44ce-a9d9-d21be3952c4f)

Select the Azure Function language, in this case we select **C#**:

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/4e92a5b4-b601-4aca-9ed2-2f9aa7d60fad)

Select the Azure Function runtime libraries, we select **.NET 8**:

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/46065dc3-a58e-4044-86a4-70324271e85b)

The we select the Azure Function trigger, we select **HTTP triggered**

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/89636e89-362c-4af6-a661-9212572d2fc0)

Now we provide the Azure Function name:

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/4b813e45-e0a9-4139-8d0b-85d033835abe)

We also set the Azure Function namespace: 

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/7bdf2bbe-127f-4ccd-88fb-5ad412ead70d)

Now we grant the access rights "**Function**":

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/d4f3ac00-fe36-43aa-a7b0-6222cac5eb57)

Finally, we open in the current window the new Azure Function source code:

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/15858d08-d93f-4f42-9b22-4522df3fe0ca)

For running the function we type the command:

```
func start
```

To access the Azure Function endpoint we navigate to this URL: **http://localhost:7071/api/HttpTrigger1**

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/0eb736c4-1d6e-4f24-bce6-de4ac9f2a7ee)

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/3109dfc0-5898-44d3-a1ee-cc256d3a63f5)

Press **Ctrl+C** for stopping the application.

## 3. Load the Azure SDK for .NET libraries

In Visual Studio Code, you can use the terminal to install NuGet packages for your C# application. 
 
The command to install the **Azure SDK libraries** would be. We type these commands in the terminal window in VSCode:

```
dotnet add package Azure.Identity
dotnet add package Azure.ResourceManager.Resources
dotnet add package Azure.ResourceManager
```

Now we reference the libraries in the C# source code:

```csharp
...
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager;
using Azure;
...
```

## 4. We input the C# source code for creating the Azure Resource Group with Azure SDK for .NET

This is the code for creating the new Azure Resource Group:

```csharp
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
string rgName = "myNewRgName";
AzureLocation location = AzureLocation.WestEurope;
ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = operation.Value;
Console.WriteLine(resourceGroup.Data.Name);
```

This code is written in C# and uses the Azure SDK for .NET to interact with Azure Resource Manager (ARM). Let me break it down for you:

### 4.1. ArmClient Initialization:
```csharp
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
```

Here, an instance of ArmClient is created using the DefaultAzureCredential().

**DefaultAzureCredential** is part of the Azure Identity library and is used for automatically managing Azure Active Directory (AAD) authentication.

It tries to use various methods for authentication, such as environment variables, managed identity, or interactive login.

### 4.2. Get Default Subscription:

```csharp
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
```

It retrieves the default subscription for the authenticated user. 

The await keyword indicates that this operation is asynchronous.

### 4.3. Resource Group Information:

```csharp
string rgName = "myRgNameLCESEGUNDO";
AzureLocation location = AzureLocation.WestEurope;
```

Sets the **name** and **location** of the Azure Resource Group that you want to create or update.

### 4.4. Create or Update Resource Group:

```csharp
ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
```

Initiates an asynchronous operation to **create or update the specified resource group**. 

It uses the **CreateOrUpdateAsync** method on the ResourceGroups property of the subscription. 

The **WaitUntil.Completed** parameter indicates that the code should wait until the operation is completed.

### 4.5. Get Resource Group Information:

```csharp
ResourceGroupResource resourceGroup = operation.Value;
```

Retrieves the result of the asynchronous operation. 

The Value property contains the actual **ResourceGroupResource** object.

### 4.6. Print Resource Group Name:

```csharp
Console.WriteLine(resourceGroup.Data.Name);
```

**Prints the resourcegroup name in the console**.

In summary, this code authenticates the user using Azure Identity, gets the default subscription, creates or updates a resource group with a specified name and location, and then prints the name of the resource group to the console.

## 5. This is the whole Azure Function C# source code.

```csharp
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

            string rgName = "myNewRgName";
            AzureLocation location = AzureLocation.WestEurope;
            ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = operation.Value;
            Console.WriteLine(resourceGroup.Data.Name);

            return response;
        }
    }
}
```

**IMPORTANT NOTE**: please pay attention and see the Azure Function call with "**RunAsync**" method. 

We used the "**async**" and the "**Task**" keywords:

```csharp
[Function("HttpTrigger1")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
```

## 6. For checking we created the new ResourceGroup in Azure

We login in Azure 

We select "Resource Groups" and we check the new resource group named "" was created:

![image](https://github.com/luiscoco/Azure_SDK_Sample4_Create_AzureResourceGroup_with_AzureFunction/assets/32194879/8ebf703a-a1f0-4952-98b0-a40a56cf620f)

