using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using WebStoreApp.Models;

namespace WebStoreApp.Data
{
	public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client()
                {
                    Id = "1",
                    Nombre = "Alexander Merino",
                    Edad = "39",
                    Correo = "alexmerino67@gmail.com"
                },
                new Client()
                {
                    Id = "2",
                    Nombre = "Maria Emilia Merino",
                    Edad = "3",
                    Correo = "mariaemilia@gmail.com"
                },
                new Client()
                {
                    Id = "3",
                    Nombre = "Martina Merino",
                    Edad = "6",
                    Correo = "martina67@gmail.com"
                }
            );
        }
    }
}

