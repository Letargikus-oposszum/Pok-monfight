using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace pokefos
{
    public class PokemonDBContext : DbContext
    {
        public DbSet<PokemonData> Pokemon { get; set; }
        public DbSet<Fight> Fights { get; set; }
        public DbSet<FightRound> FightRounds { get; set; }

        public string DbPath { get; }

        public PokemonDBContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
             => options.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Pokefos;Integrated Security=true");
    }
}
