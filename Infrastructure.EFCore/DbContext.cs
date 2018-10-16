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
    }
}
