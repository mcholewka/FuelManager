using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FuelManagerMVC.Models
{
    public class Refuel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Station { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

    }
}
