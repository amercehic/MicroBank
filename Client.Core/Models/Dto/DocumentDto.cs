using Client.Core.Entities.Client;
using Client.Core.Models.Dto.Client;
using MicroBank.Common.Models;
using System;

namespace Client.Core.Models.Dto
{
    public class DocumentDto : BaseDto<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Uri DocumentUrl { get; set; }
        public ClientDto Client { get; set; }

        public DocumentDto(Document entity) : base(entity)
        {
            Title = entity.Title;
            Description = entity.Description;
            DocumentUrl = entity.Url;
            Client = new ClientDto(entity.Client);
        }
    }
}
