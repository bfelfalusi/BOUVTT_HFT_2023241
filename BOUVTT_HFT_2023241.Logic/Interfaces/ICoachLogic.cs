using BOUVTT_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace BOUVTT_HFT_2023241.Logic.Interfaces
{
    public interface ICoachLogic
    {
        IEnumerable<double> AvgPlayerHeightPerCoach(string coachPosition);
        void Create(Coach item);
        void Delete(int id);
        Coach Read(int id);
        IQueryable<Coach> ReadAll();
        void Update(Coach item);
    }
}