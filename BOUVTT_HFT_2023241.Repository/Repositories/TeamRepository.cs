using BOUVTT_HFT_2023241.Models;
using BOUVTT_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Repository.Repositories
{
    public class TeamRepository : Repository<Team>, IRepository<Team>
    {
        public TeamRepository(PlayerDbContext db) : base(db)
        {
        }

        public override Team Read(int id)
        {
            return db.Teams.FirstOrDefault(t => t.TeamId == id);
        }

        public override void Update(Team item)
        {
            var old = Read(item.TeamId);
            foreach (var p in old.GetType().GetProperties())
            {
                p.SetValue(old, p.GetValue(item));
            }
            db.SaveChanges();
        }
    }
}
