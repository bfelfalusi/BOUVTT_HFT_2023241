using BOUVTT_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Repository.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected PlayerDbContext db;
        public Repository(PlayerDbContext db)
        {
            this.db = db;
        }
        public void Create(T item)
        {
            db.Set<T>().Add(item);
            db.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return db.Set<T>();
        }

        public void Delete(int id)
        {
            db.Set<T>().Remove(Read(id));
            db.SaveChanges();
        }

        public abstract T Read(int id);
        public abstract void Update(T item);

    }
}
