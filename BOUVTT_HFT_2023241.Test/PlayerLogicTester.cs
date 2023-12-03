using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using BOUVTT_HFT_2023241.Logic.Classes;
using BOUVTT_HFT_2023241.Models;
using BOUVTT_HFT_2023241.Repository.Interfaces;
using Moq;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace BOUVTT_HFT_2023241.Test
{
    [TestFixture]
    public class PlayerLogicTester
    {
        PlayerLogic pl;
        Mock<IRepository<Player>> mockPlayerRep;

        //ARRANGE
        [SetUp]
        public void Init()
        {

            mockPlayerRep = new Mock<IRepository<Player>>();
            mockPlayerRep.Setup(p => p.ReadAll()).Returns(new List<Player>()
            {
                new Player()
                {
                    PlayerId = 1,
                    PlayerName = "Player1",
                    Height = 190,
                    JerseyNumber = 0,
                    Trainings = new List<Training>()
                    {
                        new Training()
                        {
                            TrainingType =  "Talk-over"
                        },
                        new Training()
                        {
                            TrainingType =  "Floater Training"
                        }
                    }
                }
            }.AsQueryable());

            pl = new PlayerLogic(mockPlayerRep.Object);
        }

        [Test]
        public void GetTrainingTypesByPlayerNameTester()
        {
            var actual = pl.GetTrainingTypesByPlayerName("Player1");

            var expected = new List<string>()
            {
                "Talk-over",
                "Floater Training"
            }; 

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void CreatePlayerTestWithIncorrectInput()
        {
            var player = new Player() { PlayerName = "" };
            try
            {
                //ACT
                pl.Create(player);
            }
            catch { }

            //ASSERT
            mockPlayerRep.Verify(p => p.Create(player), Times.Never);
        }

        [Test]
        public void CreatePlayerTestWithCorrectInputs()
        {
            var player = new Player()
            {
                PlayerName = "Josh Giddey",
                JerseyNumber = 5,
                Height  = 160
            };
           
            //ACT
            pl.Create(player);


            //ASSERT
            mockPlayerRep.Verify(p => p.Create(player), Times.Once);
        }
    }
}
