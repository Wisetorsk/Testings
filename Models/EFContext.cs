using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingDiscordRPGStuff.Models
{
    public class EFContext : DbContext
    {

        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=TestPlayerDatabase;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<PlayerModel> Players { get; set; }

    }
}
