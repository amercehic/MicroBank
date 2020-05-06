using Client.Core.Entities.Client;
using MicroBank.Common.Models;
using System;

namespace Client.Core.Models.Dto.ClientApplication
{
    public class RejectedClientApplicationDto : BaseDto<Guid>
    {
        public ClientApplicationDto ClientApplication { get; set; }
        public DateTime RejectionDate { get; set; }
        public string Reason { get; set; }
        public string Note { get; set; }

        public RejectedClientApplicationDto()
        {

        }

        public RejectedClientApplicationDto(RejectedClientApplication entity) : base(entity)
        {
            ClientApplication = entity.ClientApplication != null ? new ClientApplicationDto(entity.ClientApplication) : null;
            RejectionDate = entity.RejectionDate;
            Reason = entity.Reason;
            Note = entity.Note;
        }
    }
}
