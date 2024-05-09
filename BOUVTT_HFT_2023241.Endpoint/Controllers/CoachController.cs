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
    public class CoachController : ControllerBase
    {

        ICoachLogic cl;
        private readonly IHubContext<SignalRHub> hub;

        public CoachController(ICoachLogic cl, IHubContext<SignalRHub> hub)
        {
            this.cl = cl;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Coach> ReadAll()
        {
            return this.cl.ReadAll();
        }

        [HttpGet("{id}")]
        public Coach Read(int id)
        {
            return this.cl.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Coach value)
        {
            this.cl.Create(value);
            this.hub.Clients.All.SendAsync("CoachCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Coach value)
        {
            this.cl.Update(value);
            this.hub.Clients.All.SendAsync("CoachUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var coachToDelete = this.cl.Read(id);
            this.cl.Delete(id);
            this.hub.Clients.All.SendAsync("CoachDeleted", coachToDelete);
        }
    }
}
