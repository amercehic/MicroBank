using Client.Core.Entities.Client;
using Client.Core.Models.Dto.Client;
using MicroBank.Common.Models;
using System;

namespace Client.Core.Models.Dto.ClientApplication
{
    public class RejectedClientApplicationDto : BaseDto<Guid>
    {
        public ClientDto Client { get; set; }
        public DateTime RejectionDate { get; set; }
        public string Reason { get; set; }
        public string Note { get; set; }

        public RejectedClientApplicationDto()
        {

        }

        public RejectedClientApplicationDto(RejectedClientApplication entity) : base(entity)
        {
            Client = entity.Client != null ? new ClientDto(entity.Client) : null;
            RejectionDate = entity.RejectionDate;
            Reason = entity.Reason;
            Note = entity.Note;
        }
    }
}
