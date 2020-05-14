using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Client.Core.Models.BindingModel
{
    public class DocumentCreateBindingModel
    {
        [Required]
        public Guid? ClientId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Uri DocumentUrl { get; set; }
    }
}
