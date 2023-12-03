using BOUVTT_HFT_2023241.Logic.Classes;
using BOUVTT_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BOUVTT_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        TrainingLogic trl;

        public TrainingController(TrainingLogic trl)
        {
            this.trl = trl;
        }


        [HttpGet]
        public IEnumerable<Training> ReadAll()
        {
            return trl.ReadAll();
        }

        [HttpGet("{id}")]
        public Training Read(int id)
        {
            return trl.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Training value)
        {
            trl.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Training value)
        {
            trl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            trl.Delete(id);
        }

    }
}
