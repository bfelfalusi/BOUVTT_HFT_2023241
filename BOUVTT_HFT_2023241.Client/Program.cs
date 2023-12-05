using BOUVTT_HFT_2023241.Models;
using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;

namespace BOUVTT_HFT_2023241.Client
{
    internal class Program
    {
        static RestService restservice;
        static void Create(string entity)
        {
            if (entity == "Player")
            {
                Console.Write("Enter player's name: ");
                string name = Console.ReadLine();
                Console.Write("Enter player's height: ");
                double height = double.Parse(Console.ReadLine());
                Console.Write("Enter player's jerseynumber: ");
                int jerseynum = int.Parse(Console.ReadLine());
                restservice.Post(new Player() 
                { 
                    PlayerName = name, 
                    Height = height,
                    JerseyNumber = jerseynum

                }, 
                    "player");
            }
            else if (entity == "Team")
            {
                Console.Write("Enter team's name: ");
                string name = Console.ReadLine();
                restservice.Post(new Team()
                {
                    TeamName = name
                },
                    "team");
            }
            else if (entity == "Coach")
            {
                Console.Write("Enter coach's position: ");
                string pos = Console.ReadLine();
                restservice.Post(new Coach()
                {
                    Position = pos
                },
                    "coach");
            }
            else if (entity == "Training")
            {
                Console.Write("Enter training's type: ");
                string type = Console.ReadLine();
                restservice.Post(new Training()
                {
                    TrainingType = type
                },
                    "training");
            }
            Console.WriteLine($"\n{entity} created");
            Console.WriteLine("\n--press enter to continue--");
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Player")
            {
                List<Player> players = restservice.Get<Player>("player");
                foreach (var item in players)
                {
                    Console.WriteLine(item.PlayerId + ": " + item.PlayerName);
                }
            }
            else if (entity == "Team")
            {
                List<Team> teams = restservice.Get<Team>("team");
                foreach (var item in teams)
                {
                    Console.WriteLine(item.TeamId + ": " + item.TeamName);
                }
            }
            else if (entity == "Coach")
            {
                List<Coach> coaches = restservice.Get<Coach>("coach");
                foreach (var item in coaches)
                {
                    Console.WriteLine(item.CoachId+ ": " + item.Position);
                }
            }
            else if (entity == "Training")
            {
                List<Training> trainings = restservice.Get<Training>("training");
                foreach (var item in trainings)
                {
                    Console.WriteLine(item.TrainingId + ": " + item.TrainingType);
                }
            }
            Console.WriteLine("\n--press enter to continue--");
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Player")
            {
                Console.Write("Enter player's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Player player = restservice.Get<Player>(id, "player");
                Console.Write($"New name [old was: {player.PlayerName}]: ");
                string name = Console.ReadLine();
                Console.Write($"New height [old was: {player.Height}]: ");
                double height = double.Parse(Console.ReadLine());
                Console.Write($"New jerseynumber [old was: {player.JerseyNumber}]: ");
                int jersey = int.Parse(Console.ReadLine());
                player.PlayerName = name;
                player.Height = height;
                player.JerseyNumber = jersey;
                restservice.Put(player, "player");
            }
            else if (entity == "Team")
            {
                Console.Write("Enter team's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Team team = restservice.Get<Team>(id, "team");
                Console.Write($"New name [old was: {team.TeamName}]: ");
                string name = Console.ReadLine();
                team.TeamName = name;
                restservice.Put(team, "team");
            }
            else if (entity == "Coach")
            {
                Console.Write("Enter coach's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Coach coach = restservice.Get<Coach>(id, "coach");
                Console.Write($"New position [old was: {coach.Position}]: ");
                string pos = Console.ReadLine();
                coach.Position= pos;
                restservice.Put(coach, "coach");
            }
            else if (entity == "Training")
            {
                Console.Write("Enter training's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Training training = restservice.Get<Training>(id, "training");
                Console.Write($"New trainingtype [old was: {training.TrainingType}]: ");
                string type = Console.ReadLine();
                training.TrainingType= type;
                restservice.Put(training, "training");
            }
            Console.WriteLine($"\n{entity} updated");
            Console.WriteLine("\n--press enter to continue--");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            if (entity == "Player")
            {
                Console.Write("Enter player's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                restservice.Delete(id, "player");
            }
            else if (entity == "Team")
            {
                Console.Write("Enter team's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                restservice.Delete(id, "team");
            }
            else if (entity == "Coach")
            {
                Console.Write("Enter coach's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                restservice.Delete(id, "coach");
            }
            else if (entity == "Training")
            {
                Console.Write("Enter training's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                restservice.Delete(id, "training");
            }
            Console.WriteLine($"\n{entity} deleted");
            Console.WriteLine("\n--press enter to continue--");
            Console.ReadLine();
        }

        //noncruds
        static void MostFrequentJerseyNumber()
        {
            Console.WriteLine("Enter the coach's position: ");
            string pos = Console.ReadLine();
            List <int> jersey = restservice.Get<int>(pos, "noncrud/MostFrequentJerseyNumber");
            foreach (var item in jersey)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n--press enter to continue--");
            Console.ReadLine();
            
        }
        static void GetTeamsByTrainingMonth()
        {   
            Console.WriteLine("Enter the training's month (number, i.e: 05): ");
            int month = int.Parse(Console.ReadLine());
            List<string> teamnames = restservice.Get<string>(month.ToString(), "noncrud/GetTeamsByTrainingMonth");
            foreach (var item in teamnames)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n--press enter to continue--");
            Console.ReadLine();   
        }
        static void GetTeamsWitJerseyNumber()
        {
            Console.WriteLine("Enter the jerseynumber: ");
            int jersey = int.Parse(Console.ReadLine());
            List<string> teamnames = restservice.Get<string>(jersey.ToString(), "noncrud/GetTeamsWitJerseyNumber");
            foreach (var item in teamnames)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n--press enter to continue--");
            Console.ReadLine();
        }
        static void GetTrainingTypesByPlayerName()
        {
            Console.WriteLine("Enter the player's name: ");
            string name = Console.ReadLine();
            List<string> trainings = restservice.Get<string>(name, "noncrud/GetTrainingTypesByPlayerName");
            foreach (var item in trainings)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n--press enter to continue--");
            Console.ReadLine();
        }
        static void AvgPlayerHeightPerCoach()
        {
            Console.WriteLine("Enter the coach's position: ");
            string pos = Console.ReadLine();
            List<double> heights = restservice.Get<double>(pos, "noncrud/AvgPlayerHeightPerCoach");
            foreach (var item in heights)
            {
                Console.WriteLine(Math.Round(item,2));
            }
            Console.WriteLine("\n--press enter to continue--");
            Console.ReadLine();
        }



        static void Main(string[] args)
        {
            restservice = new RestService("http://localhost:43388/","player");

            //table menus:
            var playerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Player"))
                .Add("Create", () => Create("Player"))
                .Add("Delete", () => Delete("Player"))
                .Add("Update", () => Update("Player"))
                .Add("GetTrainingTypesByPlayerName", () => GetTrainingTypesByPlayerName())
                .Add("Exit", ConsoleMenu.Close);

            var teamSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Team"))
                .Add("Create", () => Create("Team"))
                .Add("Delete", () => Delete("Team"))
                .Add("Update", () => Update("Team"))
                .Add("GetTeamsWitJerseyNumber", () => GetTeamsWitJerseyNumber())
                .Add("Exit", ConsoleMenu.Close);

            var coachSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Coach"))
                .Add("Create", () => Create("Coach"))
                .Add("Delete", () => Delete("Coach"))
                .Add("Update", () => Update("Coach"))
                .Add("AvgPlayerHeightPerCoach", () => AvgPlayerHeightPerCoach())
                .Add("Exit", ConsoleMenu.Close);

            var trainingSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Training"))
                .Add("Create", () => Create("Training"))
                .Add("Delete", () => Delete("Training"))
                .Add("Update", () => Update("Training"))
                .Add("MostFrequentJerseyNumber", () => MostFrequentJerseyNumber())
                .Add("GetTeamsByTrainingMonth", ()=> GetTeamsByTrainingMonth())
                .Add("Exit", ConsoleMenu.Close);

            //main menu:
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
