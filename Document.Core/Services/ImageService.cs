using Document.Core.Exceptions;
using Document.Core.Intefaces.Repository;
using Document.Core.Intefaces.Services;
using Document.Core.Models;
using Document.Core.Models.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Document.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IAzureStorageRepository _azureStorageRepository;
        private readonly ImageSettings _imageSettings;

        public ImageService(IAzureStorageRepository azureStorageRepository, IOptions<ImageSettings> imageSettings)
        {
            _azureStorageRepository = azureStorageRepository;
            _imageSettings = imageSettings.Value;
        }
        public async Task<ImageDto> UploadAsync(IFormFile file)
        {
            if (!_imageSettings.AllowedContentTypes.Contains(file.ContentType))
            {
                throw new InvalidImageException(file.ContentType);
            }

            if (_imageSettings.MaximumLengthInBytes < file.Length)
            {
                throw new InvalidImageException(file.Length, _imageSettings.MaximumLengthInBytes);
            }

            var url = await _azureStorageRepository.UploadToContainerAsync(_imageSettings.DefaultContainer ?? "images", file);

            return new ImageDto(url, file.FileName, file.ContentType, file.Length);
        }
    }
}
