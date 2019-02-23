using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Entities
{
    public class Song: ISong
    {
        public int songID { get; set; }
        public IGenre songGenre { get; set; }
        public IArtist songArtist { get; set; }

        public String name { get; set; }
        public String filePath { get; set; }
        public Decimal dollarPrice { get; set; }
        public DateTime? releaseDate { get; set; }

    }
}
