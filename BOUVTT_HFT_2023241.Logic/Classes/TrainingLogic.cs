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
    public class TrainingLogic 
    {
        IRepository<Training> rep;

        public void Create(Training item)
        {
            if(item.TrainingType == null || item.TrainingType == string.Empty)
            {
                throw new ArgumentException("Training type is required!");
            }    
            rep.Create(item);
        }

        public void Delete(int id)
        {
            rep.Delete(id);
        }

        public Training Read(int id)
        {
            return rep.Read(id) ?? throw new ArgumentException("Training does not exist!");
        }

        public IQueryable<Training> ReadAll()
        {
            return rep.ReadAll();
        }

        public void Update(Training item)
        {
            rep.Update(item);
        }
    }
}
