using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebSite.Models
{
    public class ArtistModel
    {
        public int id { get; set; }
        [Display(Name ="Name")]
        public String name { get; set; }
        [Display(Name = "Description")]
        public String description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime startingDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime? endingDate { get; set; }

    }
}
