using Football.DB;
using Football.DB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Football.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly FootballContext footballContext;
        public MatchController(FootballContext footballContext)
        {
            this.footballContext = footballContext;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Match>> Get()
        {
            return this.Ok(footballContext.Matches);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult GetById(int id)
        {
            var response = footballContext.Matches.Find(id);
            if (response == default)
                this.NotFound();
            //TODO: añadir la consulta a la respuesta
            return this.Ok();
        }

        [HttpPost]
        public ActionResult Post(Match match)
        {
            var response = footballContext.Matches.Add(match).Entity;
            return this.CreatedAtAction("GetById", response.Id, response);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, Match match)
        {
            if (footballContext.Matches.Find(id) == default)
                return this.NotFound();

            footballContext.Matches.Update(match);
            return this.Ok();
        }

        //TODO: en la clase Match habría que poner validaciones
        //TODO: añadir el método DELETE
    }
}
