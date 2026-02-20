using Microsoft.EntityFrameworkCore;
using Starter_CleanArch_UAA2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Starter_CleanArch_UAA2.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Subscriber> Subscribers { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}

    
        


    

