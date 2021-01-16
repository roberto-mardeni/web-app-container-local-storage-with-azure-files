# web-app-container-local-storage-with-azure-files
Demonstrates how to run a containerized web app in Azure App Service that uses local filesystem backed by an Azure Files share.

# Usage
1. Clone the repository 
2. Open in Visual Studio
3. Use the Publish wizard to deploy the LocalStorageFileManager web app to a new or existing Azure Container Registry & App Service Container instance.
4. [Create a storage account and a File Share](https://docs.microsoft.com/en-us/azure/storage/files/storage-how-to-use-files-portal)
5. [Add the File Share to the App Service](https://docs.microsoft.com/en-us/azure/app-service/configure-connect-to-azure-storage?pivots=container-linux)
6. Add an app setting called *FileManagerPath* with the mount path defined in the previous step
7. Restart web app for the container to pick up the changes
8. Test by navigating to the site followed by the **\<app service url\>/file**
9. Create a few files and verify those are present in the Azure File share.
10. Enjoy!