using BOUVTT_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace BOUVTT_HFT_2023241.Logic.Interfaces
{
    public interface IPlayerLogic
    {
        void Create(Player player);
        void Delete(int id);
        IEnumerable<string> GetTrainingTypesByPlayerName(string playername);
        Player Read(int id);
        IQueryable<Player> ReadAll();
        void Update(Player item);
    }
}