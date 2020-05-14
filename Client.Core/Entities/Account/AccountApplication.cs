using MicroBank.Common.Models;
using System;

namespace Client.Core.Entities.Account
{
    public class AccountApplication : BaseEntity<Guid>
    {
        public Guid ClientId { get; set; }
        public string AccountType { get; set; }
    }
}
