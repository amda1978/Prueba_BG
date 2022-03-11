using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PruebaBG1.Models
{
    public partial class ModelData : DbContext
    {
        public ModelData()
            : base("name=ModelData")
        {
        }

        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Producto>()
                .Property(e => e.mrp)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Producto>()
                .Property(e => e.isPublished)
                .IsUnicode(false);
        }
    }
}
