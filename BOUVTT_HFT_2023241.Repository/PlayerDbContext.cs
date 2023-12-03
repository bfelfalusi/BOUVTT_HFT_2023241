using BOUVTT_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Repository
{
    public class PlayerDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Training> Trainings { get; set; }

        public PlayerDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(p => p
                .HasOne(p=>p.Team)
                .WithMany(t=>t.Players)
                .HasForeignKey(p=>p.TeamId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Training>()
                .HasOne(tr => tr.Coach)
                .WithMany(c => c.Trainings)
                .HasForeignKey(tr => tr.CoachId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Training>()
                .HasOne(tr => tr.Player)
                .WithMany(p => p.Trainings)
                .HasForeignKey(tr => tr.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Coach>()
                .HasMany(c => c.Players)
                .WithMany(p => p.Coaches)
                .UsingEntity<Training>
                (
                    tr => tr.HasOne(tr => tr.Player)
                        .WithMany(p=>p.Trainings)
                        .HasForeignKey(tr => tr.PlayerId)
                        .OnDelete(DeleteBehavior.Cascade),
                    tr => tr.HasOne(tr => tr.Coach)
                        .WithMany(c=>c.Trainings)
                        .HasForeignKey(tr => tr.CoachId)
                        .OnDelete(DeleteBehavior.Cascade)
                );

            modelBuilder.Entity<Player>().HasData(new Player[]
            {
                new Player("1*Jayson Tatum*203*0*1"),
                new Player("2*De'Aaron Fox*191*5*12"),
                new Player("3*Anthony Edwards*193*5*2"),
                new Player("4*Jaylen Brown*198*7*1"),
                new Player("5*Nikola Jokic*211*15*4"),
                new Player("6*Josh Giddey*203*3*8"),
                new Player("7*Paolo Banchero*208*5*3"),
                new Player("8*Giannis Antetokounmpo*211*34*5"),
                new Player("9*Stephen Curry*188*30*15"),
                new Player("10*LeBron James*206*23*14"),
                new Player("11*Julius Randle*203*30*9"),
                new Player("12*Luka Doncic*201*77*6"),
                new Player("13*Jrue Holiday*196*4*1"),
                new Player("14*Devin Booker*198*1*10"),
                new Player("15*Damian Lillard*188*0*5"),
                new Player("16*Joel Embiid*213*21*7"),
                new Player("17*Jamal Murray*193*27*4"),
                new Player("18*Myles Turner*211*33*11"),
                new Player("19*Malik Monk*190*0*12"),
                new Player("20*Moritz Wagner*211*21*3"),
                new Player("21*Jimmy Butler*201*22*13"),
                new Player("22*Bam Adebayo*206*13*13"),
                new Player("23*Kevin Durant*210*35*10"),
                new Player("24*Klay Thompson*195*11*15")
            });

            modelBuilder.Entity<Team>().HasData(new Team[]
            {
                new Team("1*Boston Celtics"),
                new Team("2*Minnesota Timberwolves"),
                new Team("3*Orlando Magic"),
                new Team("4*Denver Nuggets"),
                new Team("5*Milwaukee Bucks"),
                new Team("6*Dallas Mavericks"),
                new Team("7*Philadelphia 76ers"),
                new Team("8*Oklahoma City Thunder"),
                new Team("9*New York Knicks"),
                new Team("10*Phoenix Suns"),
                new Team("11*Indiana Pacers"),
                new Team("12*Sacramento Kings"),
                new Team("13*Miami Heat"),
                new Team("14*Los Angeles Lakers"),
                new Team("15*Golden State Warriors")
            });

            modelBuilder.Entity<Coach>().HasData(new Coach[]
            {
                new Coach("1*Head Coach"),
                new Coach("2*Assistant Coach"),
                new Coach("3*Analytical Coach"),
                new Coach("4*Statistical Coach"),
                new Coach("5*Tactical Coach"),
                new Coach("6*Guard Coach"),
                new Coach("7*Forward Coach"),
                new Coach("8*Center Coach"),
                new Coach("9*Personal Coach"),
                new Coach("10*Fitness Coach")
            });

            modelBuilder.Entity<Training>().HasData(new Training[]
            {
                new Training("1*Running Training*2023.10.01*1*10"),
                new Training("2*Forward Training*2023.11.05*2*7"),
                new Training("3*Personal Training*2023.10.24*3*9"),
                new Training("4*VOD review*2023.12.02*4*3"),
                new Training("5*Center Traning*2023.08.17*5*8"),
                new Training("6*Lifting*2023.07.08*6*10"),
                new Training("7*Guard Training*2023.12.07*7*6"),
                new Training("8*Center Training*2023.09.13*8*8"),
                new Training("9*Talk-over*2023.09.20*9*1"),
                new Training("10*Talk-over*2023.04.07*10*2"),
                new Training("11*Positional Training*2023.03.12*11*5"),
                new Training("12*Running Training*2023.05.23*12*10"),
                new Training("13*3-Point Training*2023.05.20*13*4"),
                new Training("14*Free Throw Training*2023.06.04*14*2"),
                new Training("15*Floater Training*2023.07.16*15*1"),
                new Training("16*Personal Training*2023.04.21*16*9"),
                new Training("17*Guard Training*2023.02.09*17*6"),
                new Training("18*Center Training*2023.02.10*18*8"),
                new Training("19*VOD review*2023.11.01*19*3"),
                new Training("20*3-Point Training*2023.02.17*20*4"),
                new Training("21*Forward Training*2023.06.15*21*7"),
                new Training("22*Positional Training*2023.01.19*22*5"),
                new Training("23*Defense Training*2023.10.04*23*1"),
                new Training("24*Free Throw Training*2023.12.09*24*2"),
                new Training("25*Running Training*2023.05.08*15*10"),
                new Training("26*Floater Training*2023.05.04*10*2")
            });
        }
    }
}
