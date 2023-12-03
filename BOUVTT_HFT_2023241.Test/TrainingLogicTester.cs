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
using NUnit.Framework.Constraints;
using NUnit.Framework.Interfaces;

namespace BOUVTT_HFT_2023241.Test
{
    [TestFixture]
    public class TrainingLogicTester
    {
        TrainingLogic trl;
        Mock<IRepository<Training>> mockTrainingRep;

        //ARRANGE
        [SetUp]
        public void Init()
        {

            mockTrainingRep = new Mock<IRepository<Training>>();
            mockTrainingRep.Setup(p => p.ReadAll()).Returns(new List<Training>()
            {
                new Training()
                {
                    TrainingId = 1,
                    TrainingType = "TestTraining1",
                    Time = DateTime.Parse("2023.05.05"),
                    Player = new Player()
                    {
                        PlayerName = "TestPl1",
                        Height = 170,
                        JerseyNumber = 27,
                        Team = new Team()
                        {
                            TeamName = "TestTeamName1"
                        }
                    },
                    Coach = new Coach()
                    {
                        Position = "TestCoach2"
                    }
                },
                new Training()
                {
                    TrainingId = 2,
                    TrainingType = "TestTraining2",
                    Time = DateTime.Parse("2023.10.30"),
                    Player = new Player()
                    {
                        PlayerName = "TestPl2",
                        Height = 180,
                        JerseyNumber = 20,
                        Team = new Team()
                        {
                            TeamName = "TestTeamName2"
                        }
                    },
                    Coach = new Coach()
                    {
                        Position = "TestCoach2"
                    }
                },
                new Training()
                {
                    TrainingId = 2,
                    TrainingType = "TestTraining3",
                    Time = DateTime.Parse("2023.10.12"),
                    Player = new Player()
                    {
                        PlayerName = "TestPl3",
                        Height = 190,
                        JerseyNumber = 27,
                        Team = new Team()
                        {
                            TeamName = "TestTeamName3"
                        }
                    },
                    Coach = new Coach()
                    {
                        Position = "TestCoach2"
                    }
                }
            }.AsQueryable());

            trl = new TrainingLogic(mockTrainingRep.Object);
        }

        [Test]
        public void GetTeamsByTrainingMonthTest()
        {

            var actual = trl.GetTeamsByTrainingMonth(10);

            var expected = new List<string>()
            {
                "TestTeamName2",
                "TestTeamName3"
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MostFrequentJerseyNumberTest()
        {
            var actual = trl.MostFrequentJerseyNumber("TestCoach2");

            var expected = new List<int>()
            {
                27
            };

            Assert.AreEqual(expected, actual);   
        }

        [Test]
        public void CreateTrainingTestWithIncorrectTrainingType()
        {
            var training = new Training() { TrainingType = String.Empty };

            //ACT
            try
            {
                trl.Create(training);
            }
            catch { }


            //ASSERT
            mockTrainingRep.Verify(tr => tr.Create(training), Times.Never);
        }

        [Test]
        public void CreateTrainingTestWithCorrectTrainingType()
        {
            var training = new Training() { TrainingType = "TestTrainingType" };

            //ACT
            trl.Create(training);


            //ASSERT
            mockTrainingRep.Verify(tr => tr.Create(training), Times.Once);
        }

    }
}
