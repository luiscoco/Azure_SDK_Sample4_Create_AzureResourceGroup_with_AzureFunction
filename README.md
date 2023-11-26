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


