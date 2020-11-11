using System;
using System.ComponentModel.DataAnnotations;

namespace Card.Core.Models.BindingModel
{
    public class CardCreateBindingModel
    {
        [Required]
        public Guid? AccountId { get; set; }
    }
}
