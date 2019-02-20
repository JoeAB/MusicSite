using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Entities
{
    public class Song
    {
        public int songID { get; set; }
        public Genre songGenre { get; set; }
        public Artist songArtist { get; set; }

        public String name { get; set; }
        public String filePath { get; set; }
        public Decimal dollarPrice { get; set; }
        public DateTime? releaseDate { get; set; }

    }
}
