using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Pos_backend.Models
{
    public partial class AppDbContext : IdentityDbContext
    {
        private readonly IConfiguration configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
        public virtual DbSet<ProductoVenta> ProductosVentas { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

                optionsBuilder.UseSqlServer(configuration.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            //modelBuilder.Entity<Producto>(entity =>
            //{

            //    entity.Property(e => e.FechaCreacion)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Id).ValueGeneratedOnAdd();
            //});

            //OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
