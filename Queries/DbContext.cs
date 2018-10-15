using Domain.Bank;
using Microsoft.EntityFrameworkCore;
using Queries.Entities;
using Queries.Shared;

namespace Queries
{
    class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<BankDTO> Banks { get; set; }
        public DbSet<AtmDTO> Atms { get; set; }
        public DbSet<ManagerDTO> Managers { get; set; }

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
                    ATM_ID = 1,
                    CASH_BALANCE = 100
                },
                new AtmDTO
                {
                    ATM_ID = 2,
                    CASH_BALANCE = 200
                },
                new AtmDTO
                {
                    ATM_ID = 3,
                    CASH_BALANCE = 300
                });
        }
    }
}
