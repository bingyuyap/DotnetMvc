using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotnetMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the overriden method as well.
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Restaurant)
                .WithMany(r => r.Items)
                .HasForeignKey(i => i.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
