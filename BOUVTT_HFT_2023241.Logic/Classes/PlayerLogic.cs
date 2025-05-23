﻿using BOUVTT_HFT_2023241.Logic.Interfaces;
using BOUVTT_HFT_2023241.Models;
using BOUVTT_HFT_2023241.Repository;
using BOUVTT_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Transactions;

namespace BOUVTT_HFT_2023241.Logic.Classes
{
    public class PlayerLogic : IPlayerLogic
    {
        IRepository<Player> rep;

        public PlayerLogic(IRepository<Player> rep)
        {
            this.rep = rep;
        }

        public void Create(Player player)
        {
            if (player.JerseyNumber > 99 || player.JerseyNumber < 0)
            {
                throw new ArgumentException("Jerseynumber can be between 0 and 100!");
            }
            else if (player.PlayerName.Length <4 )
            {
                throw new ArgumentException("Playername is too short!");
            }
            else if (player.Height < 0)
            {
                throw new ArgumentException("Height must be a positive number!");
            }
            rep.Create(player);
        }

        public void Delete(int id)
        {
            rep.Delete(id);
        }

        public Player Read(int id)
        {
            return rep.Read(id) ?? throw new ArgumentException("Player does not exist!");
        }

        public IQueryable<Player> ReadAll()
        {
            return rep.ReadAll();
        }

        public void Update(Player item)
        {
            rep.Update(item);
        }

        //noncrud
        public IEnumerable<string> GetTrainingTypesByPlayerName(string playername)
        {
            var linq = rep.ReadAll()
                .Where(p => p.PlayerName == playername)
                .Select(p=>p.Trainings).FirstOrDefault();
            
            List<string> returnlist = new List<string>();
            if (linq != null) 
            {
                foreach (var trainings in linq)
                {
                    returnlist.Add(trainings.TrainingType);
                }
            }

            return returnlist;
        }

    }
}
