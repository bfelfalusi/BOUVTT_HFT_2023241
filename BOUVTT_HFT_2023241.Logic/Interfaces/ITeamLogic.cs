using BOUVTT_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace BOUVTT_HFT_2023241.Logic.Interfaces
{
    public interface ITeamLogic
    {
        void Create(Team item);
        void Delete(int id);
        IEnumerable<string> GetTeamsWitJerseyNumber(int jersey);
        Team Read(int id);
        IQueryable<Team> ReadAll();
        void Update(Team item);
    }
}