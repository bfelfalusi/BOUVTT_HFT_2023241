using BOUVTT_HFT_2023241.Models;
using BOUVTT_HFT_2023241.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.ValueGeneration;
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

        public TrainingLogic(IRepository<Training> rep)
        {
            this.rep = rep;
        }

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

        //noncrud
        public IEnumerable<string> GetPlayersByTrainingMonth(int month)
        {
            return (rep.ReadAll()
                .Where(t => t.Time.Month == month)
                .Select(t => t.Player)
                .Select(p=>p.Team.TeamName));
        }

        public IEnumerable<int> MostFrequentJerseyNumber(string coachPosition)
        {
            var linq = rep.ReadAll()
                .Where(tr=>tr.Coach.Position==coachPosition)
                .Select(tr=>tr.Player);
            
            int[] arr = new int[100];
            ;
            foreach (var player in linq)
            {
                arr[player.JerseyNumber]++;
            }

            List<int> returnlist = new List<int> { Array.IndexOf(arr,arr.Max()) };
            
            return returnlist;

        }
    }
}
