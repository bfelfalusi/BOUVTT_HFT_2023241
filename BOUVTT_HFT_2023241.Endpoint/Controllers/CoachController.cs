using BOUVTT_HFT_2023241.Logic.Classes;
using BOUVTT_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BOUVTT_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        CoachLogic cl;

        public CoachController(CoachLogic cl)
        {
            this.cl = cl;
        }


        [HttpGet]
        public IEnumerable<Coach> ReadAll()
        {
            return cl.ReadAll();
        }

        [HttpGet("{id}")]
        public Coach Read(int id)
        {
            return cl.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Coach value)
        {
            cl.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Coach value)
        {
            cl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }

    }
}
