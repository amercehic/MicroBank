using MicroBank.Common.Models;

namespace Account.Core.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
