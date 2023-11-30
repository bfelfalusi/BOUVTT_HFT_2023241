using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Models
{
    public class Training
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrainingId { get; set; }

        public DateTime Time { get; set; }
        public string TrainingType { get; set; }

        public int CoachId { get; set; }
        public int PlayerId { get; set; }
        [NotMapped]
        public virtual Player Player { get; set; }
        [NotMapped]
        public virtual Coach Coach { get; set; }

        public Training()
        {
            
        }

        public Training(string line)
        {
            string[] lines = line.Split('*');
            TrainingId = int.Parse(lines[0]);
            TrainingType = lines[1];
            Time = DateTime.Parse(lines[2]);
            PlayerId = int.Parse(lines[3]);
            CoachId = int.Parse(lines[4]);
        }
    }
}
