using Fotball.DB.Models;
using System.Collections.Generic;

namespace Football.DB.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
        public int MinutesPlayed { get; set; }

        public ICollection<HousePlayer> HousePlayers { get; set; }
        public ICollection<AwayPlayer> AwayPlayers { get; set; }

    }
}
