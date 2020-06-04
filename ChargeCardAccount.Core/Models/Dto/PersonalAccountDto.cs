using MicroBank.Common.Models;
using System;

namespace ChargeCardAccount.Core.Models.Dto
{
    public class PersonalAccountDto : BaseDto<Guid>
    {
        public Guid? ClientId { get; set; }
        public Guid? ProductId { get; set; }
        public string AccountType { get; set; }
        public string AccountSubType { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string AccountStatus { get; set; }
        public int CurrencyId { get; set; }
        public string Description { get; set; }
        public string Nickname { get; set; }

    }
}
