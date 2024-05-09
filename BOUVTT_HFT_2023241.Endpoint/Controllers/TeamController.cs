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
    public class TeamController : ControllerBase
    {

        ITeamLogic tl;
        private readonly IHubContext<SignalRHub> hub;

        public TeamController(ITeamLogic tl, IHubContext<SignalRHub> hub)
        {
            this.tl = tl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("TeamCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Team value)
        {
            this.tl.Update(value);
            this.hub.Clients.All.SendAsync("TeamUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var teamToDelete = this.tl.Read(id);
            this.tl.Delete(id);
            this.hub.Clients.All.SendAsync("TeamDeleted", teamToDelete);
        }
    }
}
