 using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data
{/// <summary>
/// /
/// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
                 
        public DbSet<Models.Library> Libraries { get; set; }

        public DbSet<Editorial> Editorials { get; set; }
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //modelBuilder.Entity<Models.Library>()
        //    //    .HasIndex(t => t.Titulo)
        //    //    .IsUnique();
        //}

    }
}
