using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageDemoProject.Models
{
    public class Club
    {
        public int ID { get; set; }

        [Required]
        public string Slot { get; set; }

        [DataType(DataType.Date)]
        public DateTime EntryTime { get; set; } = DateTime.Now;

        [Required]
        public decimal Price { get; set; }
    }
}
