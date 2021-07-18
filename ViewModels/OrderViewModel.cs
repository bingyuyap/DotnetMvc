using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DotnetMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMvc.ViewModels
{
    [AutoMap(typeof(Order))]
    public class OrderViewModel
    {
        public OrderViewModel()
        {
        }

        public Guid Id { get; set; }
        
        public DateTime ExpiryDateTime { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        public bool Expired { get; set; }
        
        public ICollection<Item> Items { get; set; }
        
        
    }
}