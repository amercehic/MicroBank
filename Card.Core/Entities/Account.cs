using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Card.Core.Entities
{
    public class Account : BaseEntity<Guid>
    {
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public Guid? ClientId { get; set; }
        [Required]
        public Guid? ProductId { get; set; }
        [Required]
        [StringLength(30)]
        public string AccountType { get; set; }
        [Required]
        [StringLength(30)]
        public string AccountSubType { get; set; }
        [Required]
        public string AccountStatus { get; set; }
        public DateTime AccountStatusUpdateDateTime { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [Required]
        public Guid? CardId { get; set; }
        public virtual Balance Balance { get; set; }


        #region NavProp
        public Card Card { get; set; }
        public Currency Currency { get; set; }
        #endregion NavProp
    }
}
