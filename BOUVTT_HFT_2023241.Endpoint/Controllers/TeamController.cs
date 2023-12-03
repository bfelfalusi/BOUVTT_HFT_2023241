using BOUVTT_HFT_2023241.Logic.Interfaces;
using BOUVTT_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        ITeamLogic tl;

        public TeamController(ITeamLogic tl)
        {
            this.tl = tl;
        }

        [HttpGet]
        public IEnumerable<Team> ReadAll()
        {
            return this.tl.ReadAll();
        }

        [HttpGet("{id}")]
        public Team Read(int id)
        {
            return this.tl.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Team value)
        {
            this.tl.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Team value)
        {
            this.tl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.tl.Delete(id);
        }
    }
}
