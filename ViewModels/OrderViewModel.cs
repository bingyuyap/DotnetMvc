using System;
using System.Collections;
using System.Collections.Generic;
using DotnetMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMvc.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
        }
        
        // public OrderViewModel(Guid id, DateTime expiryDateTime, DateTime createdAt, DateTime updatedAt, bool expired)
        // {
        //     Id = id;
        //     expiryDateTime = 
        // }
        
        public Guid Id { get; set; }
        
        public DateTime ExpiryDateTime { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        public bool Expired { get; set; }
        
        public ICollection<Item> Items { get; set; }
        
        
    }
}