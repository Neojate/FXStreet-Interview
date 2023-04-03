using Football.DB.Models;

namespace Fotball.DB.Models
{
    public class HousePlayer
    {
        public int Id { get; set; }

        public Player Player { get; set; }
        public Match Match { get; set; }
    }
}
