using System;
using Domain.Bank;
using Infrastructure.EFCore.Entities;
using Infrastructure.EFCore.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore
{
    class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<AtmDTO> Atms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("AtmInMemory");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed in-memory data
            modelBuilder.Entity<Atm>().HasData(
                new AtmDTO
                {
                    ATM_ID = new Identity(Guid.NewGuid()),
                    CASH_BALANCE = 100
                },
                new AtmDTO
                {
                    ATM_ID = new Identity(Guid.NewGuid()),
                    CASH_BALANCE = 200
                },
                new AtmDTO
                {
                    ATM_ID = new Identity(Guid.NewGuid()),
                    CASH_BALANCE = 300
                });
        }
    }
}
