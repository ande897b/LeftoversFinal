using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheLeftOversClubTest.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
        [Display(Name = "Pris")]
        public double Price { get; set; }
        [Display(Name = "Fuld Beskrivelse af produktet")]
        public string AdvancedDescription { get; set; }
        public string Picture { get; set; }
    }
}
