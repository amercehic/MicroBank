using MicroBank.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Card.Core.Entities
{
    public class Balance : BaseEntity<Guid>
    {
        public virtual Amount Amount { get; set; }
        public string CreditDebitIndicator { get; set; }
        public string BalanceType { get; set; }
        public DateTime DateOfBalance { get; set; }
        public virtual CreditLine CreditLine { get; set; }
    }
}
