using BOUVTT_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace BOUVTT_HFT_2023241.Logic.Interfaces
{
    public interface ITrainingLogic
    {
        void Create(Training item);
        void Delete(int id);
        IEnumerable<string> GetTeamsByTrainingMonth(int month);
        IEnumerable<int> MostFrequentJerseyNumber(string coachPosition);
        Training Read(int id);
        IQueryable<Training> ReadAll();
        void Update(Training item);
    }
}