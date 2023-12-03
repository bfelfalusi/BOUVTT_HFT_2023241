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
    public class TeamLogicTester
    {
        TeamLogic tl;
        Mock<IRepository<Team>> mockTeamRep;

        //ARRANGE
        [SetUp]
        public void Init()
        {

            mockTeamRep = new Mock<IRepository<Team>>();
            mockTeamRep.Setup(p => p.ReadAll()).Returns(new List<Team>()
            {
                new Team()
                {
                    TeamId = 1,
                    TeamName = "TestTeamName1",
                    Players = new List<Player>()
                    {
                        new Player()
                        {
                            PlayerName = "TestPl1",
                            Height = 180,
                            JerseyNumber = 1
                        },
                        new Player()
                        {
                            PlayerName = "TestPl2",
                            Height = 200,
                            JerseyNumber = 37
                        }
                    }
                },
                new Team()
                {
                    TeamId = 2,
                    TeamName = "TestTeamName2",
                    Players = new List<Player>()
                    {
                        new Player()
                        {
                            PlayerName = "TestPl3",
                            Height = 170,
                            JerseyNumber = 5
                        },
                        new Player()
                        {
                            PlayerName = "TestPl4",
                            Height = 210,
                            JerseyNumber = 8
                        }
                    }
                },
                new Team()
                {
                    TeamId = 3,
                    TeamName = "TestTeamName3",
                    Players = new List<Player>()
                    {
                        new Player()
                        {
                            PlayerName = "TestPl5",
                            Height = 190,
                            JerseyNumber = 19
                        },
                        new Player()
                        {
                            PlayerName = "TestPl6",
                            Height = 170,
                            JerseyNumber = 1
                        }
                    }
                }
            }.AsQueryable());

            tl = new TeamLogic(mockTeamRep.Object);
        }

        [Test]
        public void GetTeamsWitJerseyNumberTest()
        {

            var actual = tl.GetTeamsWitJerseyNumber(1);

            var expected = new List<string>()
            {
                "TestTeamName1",
                "TestTeamName3"
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateTeamTestWithIncorrectTeamName()
        {
            var team = new Team() { TeamName = "" };
            try
            {
                //ACT
                tl.Create(team);
            }
            catch { }

            //ASSERT
            mockTeamRep.Verify(t => t.Create(team), Times.Never);
        }

        [Test]
        public void CreateTeamTestWithCorrectTeamName()
        {
            var team = new Team() { TeamName = "TestTeamName" };

            //ACT
            tl.Create(team);


            //ASSERT
            mockTeamRep.Verify(t => t.Create(team), Times.Once);
        }

    }
}
