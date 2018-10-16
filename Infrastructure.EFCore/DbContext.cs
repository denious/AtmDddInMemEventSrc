using System;
using Infrastructure.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore
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
            var bank1Id = Guid.NewGuid();
            var bank2Id = Guid.NewGuid();
            var man1Id = Guid.NewGuid();
            var man2Id = Guid.NewGuid();

            // seed in-memory data
            modelBuilder.Entity<BankDTO>().HasData(
                new BankDTO
                {
                    Id = bank1Id,
                    Address = "123 Street",
                    ManagerId = man1Id
                },
                new BankDTO
                {
                    Id = bank2Id,
                    Address = "444 Avenue",
                    ManagerId = man2Id
                });

            modelBuilder.Entity<AtmDTO>().HasData(
                new AtmDTO
                {
                    Id = Guid.NewGuid(),
                    BankId = bank1Id,
                    CashBalance = 10000
                },
                new AtmDTO
                {
                    Id = Guid.NewGuid(),
                    BankId = bank1Id,
                    CashBalance = 500
                },
                new AtmDTO
                {
                    Id = Guid.NewGuid(),
                    BankId = bank2Id,
                    CashBalance = 15000
                });

            modelBuilder.Entity<ManagerDTO>().HasData(
                new ManagerDTO
                {
                    Id = man1Id,
                    Name = "Patton"
                },
                new ManagerDTO
                {
                    Id = man2Id,
                    Name = "Darryl"
                });
        }
    }
}
