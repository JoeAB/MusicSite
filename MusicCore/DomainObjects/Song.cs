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
        public int songGenreID { get; set; }
        public int songArtistID { get; set; }
        public List<int> songAlbumIDs { get; set; }

        public String name { get; set; }
        public String filePath { get; set; }
        public String videoPath { get; set; }
        public DateTime releaseDate { get; set; }
    }
}
