﻿using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Core.Entities.Client
{
    public class RejectedClientApplication : BaseEntity<Guid>
    {
        [Required]
        public Guid ClientApplicationId { get; set; }
        public DateTime RejectionDate { get; set; }
        [Required]
        [StringLength(100)]
        public string Reason { get; set; }
        [StringLength(200)]
        public string Note { get; set; }


        #region Navigation properties
        public ClientApplication ClientApplication { get; set; }
        #endregion
    }
}