using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebSite.Models
{
    public class AlbumModel
    {
        public int id { get; set; }
        [Display(Name = "Name")]
        public String name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime? releaseDate { get; set; }
        [Display(Name = "Cover Image Path")]
        public String coverImagePath { get; set; }
    }
}
