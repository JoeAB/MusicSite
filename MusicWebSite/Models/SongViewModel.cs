using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebSite.Models
{
    public class SongViewModel
    {
        public int id { get; set; }
        public GenreViewModel genre { get; set; }
        public ArtistViewModel artist { get; set; }

        public String name { get; set; }
        public String filePath { get; set; }
        public DateTime releaseDate { get; set; }
    }
}
