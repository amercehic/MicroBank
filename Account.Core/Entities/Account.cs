using MicroBank.Common.Models;
using System;

namespace Account.Core.Entities
{
    public class Account : BaseEntity<Guid>
    {
        public string AccountNumber { get; set; }
        public Guid? BalanceId { get; set; }

        #region NavProp
        public Balance Balance { get; set; }
        #endregion NavProp
    }
}
