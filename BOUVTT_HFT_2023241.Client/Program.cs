using BOUVTT_HFT_2023241.Repository;
using System;
using System.Linq;
using System.Threading.Channels;

namespace BOUVTT_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameDbContext ctx = new GameDbContext();
            ctx.Games.ToList().ForEach(game => Console.WriteLine(game.GameName));
        }
    }
}
