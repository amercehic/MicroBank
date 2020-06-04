using MicroBank.Common.Models;
using System;

namespace Account.Core.Entities
{
    public class Balance : BaseEntity<Guid>
    {
        public Decimal Amount { get; set; }
    }
}
