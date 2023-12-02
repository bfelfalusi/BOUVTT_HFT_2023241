using BOUVTT_HFT_2023241.Models;
using BOUVTT_HFT_2023241.Repository.Interfaces;
using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Logic.Classes
{
    public class CoachLogic
    {
        IRepository<Coach> rep;

        public CoachLogic(IRepository<Coach> rep)
        {
            this.rep = rep;
        }

        public IQueryable<Coach> ReadAll()
        {
            return rep.ReadAll();
        }

        public Coach Read(int id)
        {
            return rep.Read(id) ?? throw new ArgumentException("Coach does not exist!");
        }

        public void Create(Coach item)
        {
            if (item.Position == null || item.Position == string.Empty)
            {
                throw new ArgumentException("Coach position is required!");
            }
            rep.Create(item);
        }

        public void Update(Coach item)
        {
            rep.Update(item);
        }

        public void Delete(int id)
        {
            rep.Delete(id);
        }

        //noncruds
        public IEnumerable<double> AvgPlayerHeightPerCoach(string coachPosition)
        {
           return rep.ReadAll()
                .Where(c=>c.Position == coachPosition)
                .Select(t => t.Players.Sum(x => x.Height)/ t.Players.Count());
        }

    }
}
