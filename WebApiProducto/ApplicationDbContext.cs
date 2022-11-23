using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiProducto.Entidades;

namespace WebApiProducto
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmpresaProductos>().HasKey(al => new { al.EmpresaId, al.ProductosId });
        }

        public DbSet<Productos> Productos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Opiniones> Opiniones { get; set; }
        public DbSet<EmpresaProductos> EmpresaProductos { get; set; }
    }
}
