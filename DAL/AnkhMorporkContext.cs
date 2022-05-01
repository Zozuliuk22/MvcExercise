using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL
{
    public class AnkhMorporkContext : IdentityDbContext
    {
        public DbSet<AssassinNpc> Assassin { get; set; }

        public DbSet<BeggarNpc> Beggar { get; set; }

        public DbSet<FoolNpc> Fool { get; set; }

        public AnkhMorporkContext(DbContextOptions<AnkhMorporkContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AssassinNpc>().HasData(DataSets.Assassins);
            builder.Entity<BeggarNpc>().HasData(DataSets.Beggars);
            builder.Entity<FoolNpc>().HasData(DataSets.Fools);
        }
    }
}
