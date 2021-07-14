using System;

namespace DotnetMvc.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid RestaurantId { get; set; }
    }
}