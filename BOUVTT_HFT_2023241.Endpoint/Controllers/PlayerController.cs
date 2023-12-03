using BOUVTT_HFT_2023241.Logic.Classes;
using BOUVTT_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BOUVTT_HFT_2023241.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        PlayerLogic pl;

        public PlayerController(PlayerLogic pl)
        {
            this.pl = pl;
        }

        
        [HttpGet]
        public IEnumerable<Player> ReadAll()
        {
            return pl.ReadAll();
        }

        [HttpGet("{id}")]
        public Player Read(int id)
        {
            return pl.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Player value)
        {
            pl.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Player value)
        {
            pl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }

    }
}
