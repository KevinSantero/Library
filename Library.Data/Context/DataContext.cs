
using TecnicalTestPersonas.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TecnicalTestPersonas.Data
{   
    /// <summary>
    /// /
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
     
        public DbSet<Tercero> Terceros { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //modelBuilder.Entity<Models.TecnicalTestPersonas>()
        //    //    .HasIndex(t => t.Titulo)
        //    //    .IsUnique();
        //}

    }
}
