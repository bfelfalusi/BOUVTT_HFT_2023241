using BOUVTT_HFT_2023241.Logic.Interfaces;
using BOUVTT_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {

        ICoachLogic cl;

        public CoachController(ICoachLogic cl)
        {
            this.cl = cl;
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
        }

        [HttpPut]
        public void Update([FromBody] Coach value)
        {
            this.cl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.cl.Delete(id);
        }
    }
}
