﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheEmporium.Models;

namespace TheEmporium.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
    }
}
