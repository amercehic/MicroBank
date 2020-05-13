using Document.Core.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Document.Core.Intefaces.Services
{
    public interface IImageService
    {
        Task<ImageDto> UploadAsync(IFormFile file);
    }
}
