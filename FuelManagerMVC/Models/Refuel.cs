﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public double Amount { get; set; }
        public double Price { get; set; }

    }
}
