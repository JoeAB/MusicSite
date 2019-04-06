using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebSite.Models
{
    public class SongModel
    {
        public int id { get; set; }
        public int songGenreID { get; set; }
        public int songArtistID { get; set; }

        public String name { get; set; }
        public String filePath { get; set; }
        public String videoPath { get; set; }
        [DataType(DataType.Date)]
        public DateTime releaseDate { get; set; }
    }
}
