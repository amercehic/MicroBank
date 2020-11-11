using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Account.Core.Entities
{
    public class Account : BaseEntity<Guid>
    {
        [Required]
        public string Iban { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public Guid? MainAccountId { get; set; }
        [Required]
        public Guid? ProductId { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        public string AccountType { get; set; }

        #region NavProp
        public MainAccount MainAccount { get; set; }
        #endregion NavProp
    }
}
