using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }

        [StringLength(50)]
        public string GameName { get; set; }

        [Range(1, 50000)]
        public int PlayerCount { get; set; }

        [Range(1, 5)]
        public double Rating { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Designer> Designers { get; set; }


        public Game()
        {

        }

        public Game(string line)
        {
            string[] split = line.Split('#');
            GameId = int.Parse(split[0]);
            GameName = split[1];
            PlayerCount = int.Parse(split[2]);
            CompanyId = int.Parse(split[3]);
            ReleaseDate = DateTime.Parse(split[4].Replace('*', '.'));
            Rating = double.Parse(split[5]);
        }
    }
}
