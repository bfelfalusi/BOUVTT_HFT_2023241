using BOUVTT_HFT_2023241.Logic.Interfaces;
using BOUVTT_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {

        ITrainingLogic trl;

        public TrainingController(ITrainingLogic trl)
        {
            this.trl = trl;
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
        }

        [HttpPut]
        public void Update([FromBody] Training value)
        {
            this.trl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.trl.Delete(id);
        }
    }
}
