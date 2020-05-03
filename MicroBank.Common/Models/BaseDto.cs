using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBank.Common.Models
{
    public class BaseDto<T>
    {
        public T Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public BaseDto()
        {

        }

        public BaseDto(BaseEntity<T> entity)
        {
            Id = entity.Id;
            CreatedAt = entity.CreatedAt.ToUniversalTime();
            UpdatedAt = entity.UpdatedAt?.ToUniversalTime();
        }
    }
}
