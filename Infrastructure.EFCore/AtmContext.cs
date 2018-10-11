using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore
{
    class AtmContext : DbContext
    {
        public DbSet<Atm> Atms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("AtmInMemory");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed in-memory data
            modelBuilder.Entity<Atm>().HasData(
                new Atm(1, 100),
                new Atm(2, 200),
                new Atm(3, 300));
        }
    }
}
