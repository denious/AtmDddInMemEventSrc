﻿using Microsoft.EntityFrameworkCore;
using Queries.ViewModels;

namespace Queries
{
    class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Atm> Atms { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("AtmInMemory");
        }
    }
}
