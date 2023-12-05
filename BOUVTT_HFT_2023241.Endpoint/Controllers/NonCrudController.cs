using BOUVTT_HFT_2023241.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace BOUVTT_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCrudController : ControllerBase
    {
        IPlayerLogic pl;
        ITeamLogic tl;
        ICoachLogic cl;
        ITrainingLogic trl;

        public NonCrudController(IPlayerLogic pl, ITeamLogic tl, ICoachLogic cl, ITrainingLogic trl)
        {
            this.pl = pl;
            this.tl = tl;
            this.cl = cl;
            this.trl = trl;

        }

        [HttpGet("{playername}")]
        public IEnumerable<string> GetTrainingTypesByPlayerName(string playername)
        {
            return this.pl.GetTrainingTypesByPlayerName(playername);
        }

        [HttpGet("{coachposition}")]
        public IEnumerable<double> AvgPlayerHeightPerCoach(string coachposition)
        {
            return this.cl.AvgPlayerHeightPerCoach(coachposition);
        }

        [HttpGet("{jerseynumber}")]
        public IEnumerable<string> GetTeamsWitJerseyNumber(int jerseynumber)
        {
            return this.tl.GetTeamsWitJerseyNumber(jerseynumber);
        }

        [HttpGet("{month}")]
        public IEnumerable<string> GetTeamsByTrainingMonth(int month)
        {
            return this.trl.GetTeamsByTrainingMonth(month);
        }

        [HttpGet("{coachposition}")]
        public IEnumerable<int> MostFrequentJerseyNumber(string coachposition)
        {
            return this.trl.MostFrequentJerseyNumber(coachposition);
        }
    }
}
