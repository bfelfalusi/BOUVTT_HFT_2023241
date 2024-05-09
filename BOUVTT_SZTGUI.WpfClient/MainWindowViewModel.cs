using BOUVTT_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace BOUVTT_SZTGUI.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        #region Players
        public RestCollection<Player> Players {  get; set; }

        private Player selectedPlayer;

        public Player SelectedPlayer
        {
            get { return selectedPlayer; }
            set {
                if (value != null)
                {
                    selectedPlayer = new Player()
                    {
                        PlayerName = value.PlayerName,
                        PlayerId = value.PlayerId,
                        Height = value.Height,
                        JerseyNumber = value.JerseyNumber
                    };
                    OnPropertyChanged();
                    (DeletePlayerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreatePlayerCommand { get; set; }
        public ICommand DeletePlayerCommand { get; set; }
        public ICommand UpdatePlayerCommand { get; set; }

        #endregion

        #region Coaches
        public RestCollection<Coach> Coaches { get; set; }

        private Coach selectedCoach;

        public Coach SelectedCoach
        {
            get { return selectedCoach; }
            set
            {
                if (value != null)
                {
                    selectedCoach = new Coach()
                    {
                        CoachId = value.CoachId,
                        Position = value.Position
                    };
                    OnPropertyChanged();
                    (DeleteCoachCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }



        public ICommand CreateCoachCommand { get; set; }
        public ICommand DeleteCoachCommand { get; set; }
        public ICommand UpdateCoachCommand { get; set; }

        #endregion

        #region Teams
        public RestCollection<Team> Teams{ get; set; }

        private Team selectedTeam;

        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if (value != null)
                {
                    selectedTeam = new Team()
                    {
                        TeamName = value.TeamName,
                        TeamId = value.TeamId,
                    };
                    OnPropertyChanged();
                    (DeleteTeamCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateTeamCommand { get; set; }
        public ICommand DeleteTeamCommand { get; set; }
        public ICommand UpdateTeamCommand { get; set; }

        #endregion

        #region Trainings
        public RestCollection<Training> Trainings { get; set; }

        private Training selectedTraining;

        public Training SelectedTraining
        {
            get { return selectedTraining; }
            set
            {
                if (value != null)
                {
                    selectedTraining = new Training()
                    {
                        TrainingType = value.TrainingType,
                        TrainingId = value.TrainingId,
                        Time = value.Time,
                        PlayerId = value.PlayerId
                    };
                    OnPropertyChanged();
                    (DeleteTrainingCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateTrainingCommand { get; set; }
        public ICommand DeleteTrainingCommand { get; set; }
        public ICommand UpdateTrainingCommand { get; set; }

        #endregion
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {

                Players = new RestCollection<Player>("http://localhost:43388/", "player", "hub");
                
                CreatePlayerCommand = new RelayCommand(() =>
                {
                    if (SelectedPlayer != null)
                    {
                        Players.Add(new Player()
                        {
                            PlayerName = SelectedPlayer.PlayerName,
                            Height = SelectedPlayer.Height,
                            JerseyNumber = SelectedPlayer.JerseyNumber
                        });
                    }
                });

                UpdatePlayerCommand = new RelayCommand(() =>
                {
                    Players.Update(SelectedPlayer);
                });

                DeletePlayerCommand = new RelayCommand(() =>
                {
                    Players.Delete(SelectedPlayer.PlayerId);
                },
                () =>
                {
                    return SelectedPlayer != null;
                });


                Coaches = new RestCollection<Coach>("http://localhost:43388/", "coach", "hub");

                CreateCoachCommand = new RelayCommand(() =>
                {
                    if(SelectedCoach!= null)
                    {
                        Coaches.Add(new Coach()
                        {
                            Position = SelectedCoach.Position
                        });
                    }
                });

                UpdateCoachCommand = new RelayCommand(() =>
                {
                    Coaches.Update(SelectedCoach);
                });

                DeleteCoachCommand = new RelayCommand(() =>
                {
                    Coaches.Delete(SelectedCoach.CoachId);
                },
                () =>
                {
                    return SelectedCoach != null;
                });


                Teams = new RestCollection<Team>("http://localhost:43388/", "team", "hub");

                CreateTeamCommand = new RelayCommand(() =>
                {
                    if (SelectedTeam != null)
                    {
                        Teams.Add(new Team()
                        {
                            TeamName= SelectedTeam.TeamName
                        }); 
                    }
                });

                UpdateTeamCommand = new RelayCommand(() =>
                {
                    Teams.Update(SelectedTeam);
                });

                DeleteTeamCommand = new RelayCommand(() =>
                {
                    Teams.Delete(SelectedTeam.TeamId);
                },
                () =>
                {
                    return SelectedTeam != null;
                });


                Trainings = new RestCollection<Training>("http://localhost:43388/", "training", "hub");

                CreateTrainingCommand = new RelayCommand(() =>
                {
                    if(SelectedTraining != null)
                    {
                        Trainings.Add(new Training()
                        {
                            TrainingType = SelectedTraining.TrainingType,
                            Time = SelectedTraining.Time,
                            PlayerId = SelectedTraining.PlayerId
                        });
                    }
                });

                UpdateTrainingCommand = new RelayCommand(() =>
                {
                    Trainings.Update(SelectedTraining);
                });

                DeleteTrainingCommand = new RelayCommand(() =>
                {
                    Trainings.Delete(SelectedTraining.TrainingId);
                },
                () =>
                {
                    return SelectedTraining != null;
                });



            }
        }
    }
}
