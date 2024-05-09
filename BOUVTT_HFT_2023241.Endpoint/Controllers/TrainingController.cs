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
    public class TrainingController : ControllerBase
    {

        ITrainingLogic trl;
        private readonly IHubContext<SignalRHub> hub;
        public TrainingController(ITrainingLogic trl, IHubContext<SignalRHub> hub)
        {
            this.trl = trl;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Training> ReadAll()
        {
            return this.trl.ReadAll();
        }

        [HttpGet("{id}")]
        public Training Read(int id)
        {
            return this.trl.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Training value)
        {
            this.trl.Create(value);
            this.hub.Clients.All.SendAsync("TrainingCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Training value)
        {
            this.trl.Update(value);
            this.hub.Clients.All.SendAsync("TrainingUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var trainingToDelete = this.trl.Read(id);
            this.trl.Delete(id);
            this.hub.Clients.All.SendAsync("TrainingDeleted", trainingToDelete);
        }
    }
}
