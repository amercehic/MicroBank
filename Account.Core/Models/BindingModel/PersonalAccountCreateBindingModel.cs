using System;
using System.ComponentModel.DataAnnotations;

namespace Account.Core.Models.BindingModel
{
    public class PersonalAccountCreateBindingModel
    {
        [Required]
        public Guid? ClientId { get; set; }
        [Required]
        public Guid? ProductId { get; set; }
        [Required]
        [StringLength(30)]
        public string AccountSubType { get; set; }
        [Required]
        public DateTime SubmittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        [Required]
        public string AccountStatus { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Nickname { get; set; }
    }
}
