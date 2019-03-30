using MusicCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCore
{
    public class Song : IPurchasable
    {
        public int id { get; set; }
        public Genre songGenre { get; set; }
        public Artist songArtist { get; set; }
        public List<Album> songAlbums { get; set; }

        public String name { get; set; }
        public String filePath { get; set; }
        public DateTime releaseDate { get; set; }
    }
}
