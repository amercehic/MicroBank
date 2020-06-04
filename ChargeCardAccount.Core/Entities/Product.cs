using MicroBank.Common.Models;

namespace ChargeCardAccount.Core.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
