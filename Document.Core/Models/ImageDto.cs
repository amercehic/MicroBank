using System;

namespace Document.Core.Models
{
    public class ImageDto
    {
        public Uri Url { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public long Length { get; set; }
        public ImageDto()
        {

        }

        public ImageDto(Uri url, string name, string contentType, long length)
        {
            Url = url;
            Name = name;
            ContentType = contentType;
            Length = length;
        }
    }
}
