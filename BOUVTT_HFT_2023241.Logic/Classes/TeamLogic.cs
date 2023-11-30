using BOUVTT_HFT_2023241.Models;
using BOUVTT_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Logic.Classes
{
    public class TeamLogic 
    {
        IRepository<Team> rep;
        public void Create(Team item)
        {
            if(item.TeamName == null || item.TeamName == string.Empty)
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
    }
}
