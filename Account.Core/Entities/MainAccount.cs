using MicroBank.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Account.Core.Entities
{
    public class MainAccount : BaseEntity<Guid>
    {
        [Required]
        public Guid? ClientId { get; set; }
        public int NumberOfAccounts { get; set; }

        #region NavProp
        public IEnumerable<Account> Accounts { get; set; }
        public Client Client { get; set; }
        #endregion    
    }
}

