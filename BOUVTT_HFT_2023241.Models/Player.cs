using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Models
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }

        [Required]
        [StringLength(50)]
        public string PlayerName { get; set; }

        public double Height { get; set; }

        public int JerseyNumber { get; set; }

        public int TeamId { get; set; }
        [NotMapped]
        public virtual Team Team { get; set; }
        [NotMapped]
        public virtual ICollection<Training> Trainings { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Coach> Coaches { get; set; }

        public Player()
        {
            
        }

        public Player(string line)
        {
            string[] lines = line.Split('*');
            PlayerId= int.Parse(lines[0]);
            PlayerName = lines[1];
            Height = int.Parse(lines[2]);
            JerseyNumber = int.Parse(lines[3]);
            TeamId = int.Parse(lines[4]);
        }
    }
}
