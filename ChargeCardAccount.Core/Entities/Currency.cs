using MicroBank.Common.Models;

namespace ChargeCardAccount.Core.Entities
{
    public class Currency : BaseEntity<int>
    {
        public string Country { get; set; }
        public string CurrencyName { get; set; }
        public string Code { get; set; }
        public int CountryNumber { get; set; }
    }
}
