using Fotball.DB.Models;
using System;
using System.Collections.Generic;

namespace Football.DB.Models
{
    public class Match
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } 

        public Manager HouseManager { get; set; }
        public Manager AwayManager { get; set; }

        public ICollection<HousePlayer> HousePlayers { get; set; }
        public ICollection<AwayPlayer> AwayPlayers { get; set; }

        public Referee Referee { get; set; }
    }
}
