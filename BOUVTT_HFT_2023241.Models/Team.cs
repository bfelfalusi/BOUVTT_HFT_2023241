using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }

        [Required]
        [StringLength(50)]
        public string TeamName { get; set; }

        [NotMapped]
        public virtual ICollection<Player> Players { get; set; }

        public Team()
        {
            Players = new List<Player>();
        }

        public Team(string line)
        {
            string[] lines = line.Split('*');
            TeamId = int.Parse(lines[0]);
            TeamName = lines[1];
            Players = new List<Player>();
            
        }
    }
}
