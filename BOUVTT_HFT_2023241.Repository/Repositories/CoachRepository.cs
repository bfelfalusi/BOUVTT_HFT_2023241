using BOUVTT_HFT_2023241.Models;
using BOUVTT_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Repository.Repositories
{
    public class CoachRepository : Repository<Coach>, IRepository<Coach>
    {
        public CoachRepository(PlayerDbContext db) : base(db)
        {
        }

        public override Coach Read(int id)
        {
            return db.Coaches.FirstOrDefault(t => t.CoachId== id);
        }

        public override void Update(Coach item)
        {
            var old = Read(item.CoachId);
            foreach (var p in old.GetType().GetProperties())
            {
                if (p.GetAccessors().FirstOrDefault(c => c.IsVirtual) == null)
                {
                    p.SetValue(old, p.GetValue(item));
                }
            }
            db.SaveChanges();
        }
    }
}
