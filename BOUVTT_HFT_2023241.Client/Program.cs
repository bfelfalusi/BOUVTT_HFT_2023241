using BOUVTT_HFT_2023241.Models;
using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Channels;

namespace BOUVTT_HFT_2023241.Client
{
    internal class Program
    {

        public static void Create(string entity) 
        {
            Console.WriteLine($"{entity} create");
            Console.ReadLine();
        }

        public static void Update(string entity)
        {
            Console.WriteLine($"{entity} update");
            Console.ReadLine();
        }

        public static void List(string entity)
        {
            Console.WriteLine($"{entity} list");
            Console.ReadLine();
        }

        public static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            var playerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Player"))
                .Add("Create", () => Create("Player"))
                .Add("Delete", () => Delete("Player"))
                .Add("Update", () => Update("Player"))
                .Add("Exit", ConsoleMenu.Close);

            var teamSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Team"))
                .Add("Create", () => Create("Team"))
                .Add("Delete", () => Delete("Team"))
                .Add("Update", () => Update("Team"))
                .Add("Exit", ConsoleMenu.Close);

            var coachSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Coach"))
                .Add("Create", () => Create("Coach"))
                .Add("Delete", () => Delete("Coach"))
                .Add("Update", () => Update("Coach"))
                .Add("Exit", ConsoleMenu.Close);

            var trainingSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Training"))
                .Add("Create", () => Create("Training"))
                .Add("Delete", () => Delete("Training"))
                .Add("Update", () => Update("Training"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Players", () => playerSubMenu.Show())
                .Add("Teams", () => teamSubMenu.Show())
                .Add("Coaches", () => coachSubMenu.Show())
                .Add("Trainings", () => trainingSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }

        
    }
}
