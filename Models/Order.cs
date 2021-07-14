using System;
using System.Collections;
using System.Collections.Generic;

namespace DotnetMvc.Models
{
    public class Order : BaseEntity
    {
        public Guid Id { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}