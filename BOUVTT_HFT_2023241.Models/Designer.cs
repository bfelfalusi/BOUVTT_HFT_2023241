using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Models
{
    public class Designer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DesignerId { get; set; }

        [Required]
        [StringLength(50)]
        public string DesignerName { get; set; }

        public Designer()
        {
            
        }

        public Designer(string line)
        {
            string[] split = line.Split('#');
            DesignerId = int.Parse(split[0]);
            DesignerName = split[1];
        }
    }
}
