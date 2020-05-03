using MicroBank.Common.Models;
using Organisation.Core.Entities;
using System;

namespace Organisation.Core.Models.Dto
{
    public class OfficeDto : BaseDto<Guid>
    {
        public string Name { get; set; }
        public OfficeDto Parent { get; set; }
        public string OfficeCode { get; set; }
        public DateTime Openingdate { get; set; }
        public bool IsMainOffice { get; set; }

        public OfficeDto()
        {

        }

        public OfficeDto(Office entity) : base(entity)
        {
            Name = entity.Name;
            Parent = entity.Parent != null ? new OfficeDto(entity.Parent) : null;
            Openingdate = entity.Openingdate;
            IsMainOffice = entity.IsMainOffice;
            OfficeCode = entity.OfficeCode;
        }
    }
}
