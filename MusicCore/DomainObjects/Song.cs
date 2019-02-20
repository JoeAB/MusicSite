using MusicCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCore
{
    class Song : IPurchasable
    {
        protected String id { get; set; }
        public Genre songGenre { get; set; }
        public Artist songArtist { get; set; }

        public String name { get; set; }
        public String filePath { get; set; }
        public Decimal price { get; set; }
    }
}
