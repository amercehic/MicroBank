using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Organisation.Core.Entities
{
    public class Office : BaseEntity<Guid>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(10)]
        public string OfficeCode { get; set; }
        public DateTime Openingdate { get; set; }
        public Guid? ParentId { get; set; }
        public bool IsMainOffice { get { return !ParentId.HasValue; } }


        #region NavProp
        private Office parent;
        public Office Parent
        {
            get => LazyLoader.Load(this, ref this.parent);
            set => this.parent = value;
        }
        #endregion
    }
}
