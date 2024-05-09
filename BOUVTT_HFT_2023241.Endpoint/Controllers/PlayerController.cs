using BOUVTT_HFT_2023241.Endpoint.Services;
using BOUVTT_HFT_2023241.Logic.Interfaces;
using BOUVTT_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        IPlayerLogic pl;
        private readonly IHubContext<SignalRHub> hub;

        public PlayerController(IPlayerLogic pl, IHubContext<SignalRHub> hub)
        {
            this.pl = pl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("PlayerCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Player value)
        {
            this.pl.Update(value);
            this.hub.Clients.All.SendAsync("PlayerUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var playerToDelete = this.pl.Read(id);
            this.pl.Delete(id);
            this.hub.Clients.All.SendAsync("PlayerDeleted", playerToDelete);
        }
    }
}
