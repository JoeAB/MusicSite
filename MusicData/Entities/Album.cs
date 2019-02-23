using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Entities
{
    public class Album : IAlbum
    {
        public int albumID { get; set; }

        public String name { get; set; }
        public Decimal dollarPrice { get; set; }
        public DateTime? releaseDate { get; set; }
    }
}
