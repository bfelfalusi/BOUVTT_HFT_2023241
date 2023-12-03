using BOUVTT_HFT_2023241.Logic.Classes;
using BOUVTT_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BOUVTT_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        TeamLogic tl;

        public TeamController(TeamLogic pl)
        {
            this.tl = pl;
        }


        [HttpGet]
        public IEnumerable<Team> ReadAll()
        {
            return tl.ReadAll();
        }

        [HttpGet("{id}")]
        public Team Read(int id)
        {
            return tl.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Team value)
        {
            tl.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Team value)
        {
            tl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tl.Delete(id);
        }

    }
}
