using Domain.ATM;
using Infrastructure.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore
{
    class AtmContext : DbContext
    {
        public DbSet<AtmDto> Atms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("AtmInMemory");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed in-memory data
            modelBuilder.Entity<Atm>().HasData(
                new AtmDto
                {
                    ATM_ID = 1,
                    CASH_BALANCE = 100
                },
                new AtmDto
                {
                    ATM_ID = 2,
                    CASH_BALANCE = 200
                },
                new AtmDto
                {
                    ATM_ID = 3,
                    CASH_BALANCE = 300
                });
        }
    }
}
