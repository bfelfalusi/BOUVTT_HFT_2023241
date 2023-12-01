using BOUVTT_HFT_2023241.Logic.Classes;
using BOUVTT_HFT_2023241.Models;
using BOUVTT_HFT_2023241.Repository;
using BOUVTT_HFT_2023241.Repository.Interfaces;
using BOUVTT_HFT_2023241.Repository.Repositories;

using System;
using System.Linq;
using System.Threading.Channels;

namespace BOUVTT_HFT_2023241.Client
{
    internal class Program
    {

        static void Main(string[] args)
        {
            PlayerDbContext db = new PlayerDbContext();
            var repo = new TrainingRepository(db);
            var logic = new TrainingLogic(repo);
            int mainap = DateTime.Now.Month;

            Training tr = new Training()
            {
                CoachId = 1,
                PlayerId = 2,
                TrainingType = ""
            };
            //logic.Create(tr);


        }
    }
}
