using BOUVTT_HFT_2023241.Models;
using BOUVTT_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Repository.Repositories
{
    public class TrainingRepository : Repository<Training>, IRepository<Training>
    {
        public TrainingRepository(PlayerDbContext db) : base(db)
        {
        }

        public override Training Read(int id)
        {
            return db.Trainings.FirstOrDefault(t => t.TrainingId== id);
        }

        public override void Update(Training item)
        {
            var old = Read(item.TrainingId);
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
