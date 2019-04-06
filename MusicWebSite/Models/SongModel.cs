using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebSite.Models
{
    public class SongModel
    {
        public int id { get; set; }
        public GenreModel genre { get; set; }
        public ArtistModel artist { get; set; }

        public String name { get; set; }
        public String filePath { get; set; }
        public DateTime releaseDate { get; set; }
    }
}
