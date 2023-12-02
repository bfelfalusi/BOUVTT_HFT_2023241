using BOUVTT_HFT_2023241.Logic.Interfaces;
using BOUVTT_HFT_2023241.Models;
using BOUVTT_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Logic.Classes
{
    public class TeamLogic : ITeamLogic
    {
        IRepository<Team> rep;

        public TeamLogic(IRepository<Team> rep)
        {
            this.rep = rep;
        }

        public void Create(Team item)
        {
            if (item.TeamName == null || item.TeamName == string.Empty)
            {
                throw new ArgumentException("Team name is required!");
            }
            rep.Create(item);
        }

        public void Delete(int id)
        {
            rep.Delete(id);
        }

        public Team Read(int id)
        {
            return rep.Read(id) ?? throw new ArgumentException("Team does not exist!");
        }

        public IQueryable<Team> ReadAll()
        {
            return rep.ReadAll();
        }

        public void Update(Team item)
        {
            rep.Update(item);
        }

        //noncrud
        public IEnumerable<string> GetTeamsWitJerseyNumber(int jersey)
        {
            return rep.ReadAll()
                .Where(t => t.Players
                .Any(t => t.JerseyNumber == jersey))
                .Select(t => t.TeamName);
        }
    }
}
