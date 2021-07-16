using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetMvc.Models
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        
        public int Quantity { get; set; }
    }
}  