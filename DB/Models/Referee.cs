using System.Collections.Generic;

namespace Football.DB.Models
{
    public class Referee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinutesPlayed { get; set; }

        public ICollection<Match> Matches { get; set; }
    }
}
