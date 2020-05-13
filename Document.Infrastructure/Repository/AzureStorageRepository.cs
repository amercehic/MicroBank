using Document.Core.Intefaces.Repository;
using Document.Core.Models.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Threading.Tasks;

namespace Document.Infrastructure.Repository
{
    public class AzureStorageRepository : IAzureStorageRepository
    {
        private readonly CloudStorageAccount _storageAccount;
        private readonly CloudBlobClient _blobClient;
        public AzureStorageRepository(IOptions<AzureStorageOptions> options)
        {
            CloudStorageAccount.TryParse(options.Value?.ConnectionString, out _storageAccount);
            _blobClient = _storageAccount.CreateCloudBlobClient();
        }

        public async Task<Uri> UploadToContainerAsync(string containerName, IFormFile file)
        {
            var fileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";

            CloudBlobContainer container = _blobClient.GetContainerReference(containerName);

            if (!await container.ExistsAsync().ConfigureAwait(false))
            {
                await container.CreateAsync().ConfigureAwait(false);
                await container.SetPermissionsAsync(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob, //public allow
                }).ConfigureAwait(false);
            }

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            // Upload the file
            await blockBlob.UploadFromStreamAsync(file.OpenReadStream()).ConfigureAwait(false);

            return blockBlob.Uri;
        }
    }
}
