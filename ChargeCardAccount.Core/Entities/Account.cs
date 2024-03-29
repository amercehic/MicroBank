﻿using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChargeCardAccount.Core.Entities
{
    public class Account : BaseEntity<Guid>
    {
        public string IBAN { get; set; }
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
        public DateTime SubmittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        [Required]
        public string AccountStatus { get; set; }
        public DateTime AccountStatusUpdateDateTime { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [Required]
        public Guid? CardId { get; set; }
        public Guid BalanceId { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public string Nickname { get; set; }


        #region NavProp
        public Client Client { get; set; }
        public Product Product { get; set; }
        public Currency Currency { get; set; }
        public Balance Balance { get; set; }
        #endregion NavProp
    }
}
