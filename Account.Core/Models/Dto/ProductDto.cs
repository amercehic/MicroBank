using Account.Core.Entities;
using MicroBank.Common.Models;

namespace Account.Core.Models.Dto
{
    public class ProductDto : BaseDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ProductDto(Product entity) : base(entity)
        {
            Name = entity.Name;
            Description = entity.Description;
        }
    }
}
