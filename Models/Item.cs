using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetMvc.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        
        // Foreign Key Reference to Restaurant Object
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }
}