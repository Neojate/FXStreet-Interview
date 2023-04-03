using Football.DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Football.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        readonly FootballContext footballContext;
        public StatisticsController(FootballContext footballContext)
        {
            this.footballContext = footballContext;
        }

        [HttpGet]
        [Route("yellowcards")]
        public ActionResult GetYellowCards()
        {
            var response = footballContext.Players.Sum(player => player.YellowCard);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("redcards")]
        public ActionResult GetRedCards()
        {
            var response = footballContext.Players.Sum(player => player.RedCard);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("minutesplayed")]
        public ActionResult GetMinutesPlayed()
        {
            var response = footballContext.Players.Sum(player => player.MinutesPlayed);
            return this.Ok(response);
        }
    }
}
