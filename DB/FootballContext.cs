using Football.DB.Models;
using Fotball.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Football.DB
{
    public class FootballContext : DbContext
    {
        public FootballContext(DbContextOptions<FootballContext> options) : base(options)
        {

        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<HousePlayer> HousePlayers { get; set; }
        public DbSet<AwayPlayer> AwayPlayers { get; set; }

    }
}
