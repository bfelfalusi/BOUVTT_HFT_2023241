using BOUVTT_HFT_2023241.Models;
using BOUVTT_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Repository.Repositories
{
    public class PlayerRepository : Repository<Player>, IRepository<Player>
    {
        public PlayerRepository(PlayerDbContext db) : base(db)
        {
        }

        public override Player Read(int id)
        {
            return db.Players.FirstOrDefault(t=>t.PlayerId == id);
        }

        public override void Update(Player item)
        {
            var old = Read(item.PlayerId);
            foreach (var p in old.GetType().GetProperties())
            {
                p.SetValue(old, p.GetValue(item));
            }
            db.SaveChanges();
        }
    }
}
