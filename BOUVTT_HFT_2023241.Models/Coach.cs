using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Models
{
    public class Coach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoachId { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        [NotMapped]
        public virtual ICollection<Player> Players  { get; set; }
        [NotMapped]
        public virtual ICollection<Training> Trainings { get; set; }

        public Coach()
        {
            
        }

        public Coach(string line)
        {
            string[] lines = line.Split('*');
            CoachId = int.Parse(lines[0]);
            Position = lines[1];
        }
    }
}
