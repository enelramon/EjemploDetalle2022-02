using EjemploDetalle2022_02.Models;
using Microsoft.EntityFrameworkCore;
namespace EjemploDetalle2022_02.DAL
{
    public class Contexto: DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Compras> Compras { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Productos>().HasData(
                new Productos
                {
                    ProductoId = 1,
                    Descripcion = "Huevos",
                    Costo = 5,
                    Precio = 7,
                    Existencia = 0
                },
                new Productos
                {
                    ProductoId = 2,
                    Descripcion = "Cebolla",
                    Costo = 50,
                    Precio = 85,
                    Existencia = 0
                }
                );
        }

    }
}
