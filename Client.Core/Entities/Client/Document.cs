using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Core.Entities.Client
{
    public class Document : BaseEntity<Guid>
    {
        public Uri Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public Guid? ClientId  { get; set; }


        #region NavProp
        public PersonalClient Client { get; set; }
        #endregion
    }
}
