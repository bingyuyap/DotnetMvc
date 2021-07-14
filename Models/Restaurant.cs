using System;
using System.Collections;
using System.Collections.Generic;

namespace DotnetMvc.Models
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        
        // A Restaurant object has many items
        public ICollection<Item> Items { get; set; }
    }
}