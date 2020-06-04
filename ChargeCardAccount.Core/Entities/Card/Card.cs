using MicroBank.Common.Models;
using System;

namespace ChargeCardAccount.Core.Entities
{
    public class Card : BaseEntity<Guid>
    {
        public int MyProperty { get; set; }
    }
}
