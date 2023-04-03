using Football.DB;
using Football.DB.Models;
using Fotball.DB.Models;
using System;
using System.Linq;

namespace Football.API
{
    public static class DbInitializer
    {
        public static void Initialize(FootballContext context)
        {
            //context.Database.EnsureCreated();

            if (context.Players.Any())
                return;

            var players = new Player[] 
            {
                new Player{ Name = "Lionel", YellowCard = 1, RedCard = 0, MinutesPlayed = 90 },
                new Player{ Name = "Cristiano", YellowCard = 1, RedCard = 0, MinutesPlayed = 90 },
                new Player{ Name = "Iker", YellowCard = 1, RedCard = 0, MinutesPlayed = 90 },
                new Player{ Name = "Gerard", YellowCard = 1, RedCard = 0, MinutesPlayed = 90 },
                new Player{ Name = "Philippe", YellowCard = 1, RedCard = 0, MinutesPlayed = 90 },
                new Player{ Name = "Jordi", YellowCard = 1, RedCard = 0, MinutesPlayed = 90 },
                new Player{ Name = "John Doe", YellowCard = 96, RedCard = 99, MinutesPlayed = 15 }
            };

            foreach (var p in players)
                context.Players.Add(p);
            context.SaveChanges();

            var managers = new Manager[] 
            {
                new Manager { Name = "Alex" },
                new Manager { Name = "Zidane" },
                new Manager { Name = "Guardiola" }
            };

            foreach (var m in managers)
                context.Managers.Add(m);
            context.SaveChanges();

            var referees = new Referee[] 
            {
                new Referee { Name = "Pierluigi" },
                new Referee { Name = "Howard" }
            };

            foreach (var r in referees)
                context.Referees.Add(r);
            context.SaveChanges();

            var match = new Match()
            {
                Date = DateTime.Now,
                Referee = referees[0],
                HouseManager = managers[1],
                AwayManager = managers[2]
            };

            context.Matches.Add(match);
            context.SaveChanges();

            var housePlayers = new HousePlayer[]
            {
                new HousePlayer { Player = players[0], Match = match },
                new HousePlayer { Player = players[3], Match = match },
                new HousePlayer { Player = players[5], Match = match }
            };

            context.HousePlayers.AddRange(housePlayers);
            context.SaveChanges();

            var awayPlayers = new AwayPlayer[]
            {
                new AwayPlayer { Player = players[1], Match = match },
                new AwayPlayer { Player = players[2], Match = match },
                new AwayPlayer { Player = players[4], Match = match }
            };

            context.AwayPlayers.AddRange(awayPlayers);
            context.SaveChanges();
        }
    }
}
