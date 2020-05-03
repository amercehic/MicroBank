using System;
using System.ComponentModel.DataAnnotations;

namespace Organisation.Core.Models.BindingModel
{
    public class OfficeCreateBindingModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(10)]
        public string OfficeCode { get; set; }
        public DateTime Openingdate { get; set; }
        public Guid? ParentId { get; set; }
    }
}
