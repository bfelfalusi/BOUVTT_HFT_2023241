using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using BOUVTT_HFT_2023241.Logic.Classes;
using BOUVTT_HFT_2023241.Models;
using BOUVTT_HFT_2023241.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace BOUVTT_HFT_2023241.Test
{
    [TestFixture]
    public class CoachLogicTester
    {
        CoachLogic cl;
        Mock<IRepository<Coach>> mockCoachRep;

        //ARRANGE
        [SetUp]
        public void Init()
        {

            mockCoachRep = new Mock<IRepository<Coach>>();
            mockCoachRep.Setup(p => p.ReadAll()).Returns(new List<Coach>()
            {
                new Coach()
                {
                    CoachId = 1,
                    Position = "CoachPosition1",
                    Players = new List<Player>()
                    {
                        new Player()
                        {
                            PlayerName = "TestPlayer1",
                            Height = 180,
                            JerseyNumber = 1
                        },
                        new Player()
                        {
                            PlayerName = "TestPlayer2",
                            Height = 200,
                            JerseyNumber = 2
                        }
                    }

                }
            }.AsQueryable());

            cl = new CoachLogic(mockCoachRep.Object);
        }

        [Test]
        public void AvgPlayerHeightPerCoachTest()
        {

            var actual = cl.AvgPlayerHeightPerCoach("CoachPosition1");

            var expected = new List<double>()
            {
                190
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateCoachWithIncorrectPosition()
        {
            var coach = new Coach() { Position = "" };
            try
            {
                //ACT
                cl.Create(coach);
            }
            catch
            {

            }

            //ASSERT
            mockCoachRep.Verify(c => c.Create(coach), Times.Never);
        }

        [Test]
        public void CreateCoachTestWithCorrectPosition()
        {
            var coach = new Coach(){ Position = "TestCoach" };

            //ACT
            cl.Create(coach);


            //ASSERT
            mockCoachRep.Verify(c => c.Create(coach), Times.Once);
        }

    }
}
