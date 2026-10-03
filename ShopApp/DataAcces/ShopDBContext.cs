using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ShopApp.DataAcces
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ShopComputer");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category(1, "Electronicos"),
                new Category(2, "Computadoras"),
                new Category(3, "Telefonos Moviles"),
                new Category(4, "Dispositivos de Escritorio"),
                new Category(5, "Microfonos y Audio"),
                new Category(6, "Artefactos del Hogar"),
                new Category(7, "Juguetes y Juegos")
                );
            modelBuilder.Entity<Product>().HasData(
                new Product(1, "Radio Digital", "Es una radio de banda ancha", 100, 1, "radio_digital.jpg"),
                new Product(2, "Reloj Electronico", "Reloj digital sumergible", 50, 1, "reloj_electronico.jpg"),
                new Product(3, "Laptop HP", "Laptop de escritorio", 900, 2, "laptop_hp.jpg"),
                new Product(4, "Laptop Acer", "Laptop Gamer", 1200, 2, "laptop_acer.jpg"),
                new Product(5, "Macbook Apple", "Gran capacidad", 1500, 2, "macbook_apple.jpg"),
                new Product(6, "Samsung Galaxy", "Smartphone 5G", 1800, 3, "samsung_galaxy.jpg"),
                new Product(7, "Iphone 14", "Apple disp", 1500, 3, "iphone.jpg")
                );
            modelBuilder.Entity<Client>().HasData(
                new Client(1, "David Martinez", "Carrera 1 54 12"),
                new Client(2, "Ronaldo Mazario", "Calle 44 12 32")
                );
        }
    }

    public record Category(int Id, string Nombre);
    public record Product(int Id, string Nombre, string Descripcion, decimal Precio, int CategoryId, string Imagen)
    {
        public Category Category { get; set; }
    }

    public record Client(int Id, string Nombre, string Direccion);

}