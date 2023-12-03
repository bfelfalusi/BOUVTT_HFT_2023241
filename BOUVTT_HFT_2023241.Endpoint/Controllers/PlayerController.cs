using BOUVTT_HFT_2023241.Logic.Interfaces;
using BOUVTT_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        IPlayerLogic pl;

        public PlayerController(IPlayerLogic pl)
        {
            this.pl = pl;
        }

        [HttpGet]
        public IEnumerable<Player> ReadAll()
        {
            return this.pl.ReadAll();
        }

        [HttpGet("{id}")]
        public Player Read(int id)
        {
            return this.pl.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Player value)
        {
            this.pl.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Player value)
        {
            this.pl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.pl.Delete(id);
        }
    }
}
