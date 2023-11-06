using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOUVTT_HFT_2023241.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(20)]
        public string CompanyName { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public Company()
        {
            Games = new HashSet<Game>();
        }

        public Company(string line)
        {
            string[] split = line.Split('#');
            CompanyId = int.Parse(split[0]);
            CompanyName = split[1];
            Games = new HashSet<Game>();
        }
    }
}
