using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Document.Core.Intefaces.Repository
{
    public interface IAzureStorageRepository
    {
        Task<Uri> UploadToContainerAsync(string containerName, IFormFile file);
    }
}
