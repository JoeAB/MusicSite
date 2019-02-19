using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Entities
{
    public class Album
    {
        public String albumID { get; set; }
        public List<Song> songs { get; set; }

        public String name { get; set; }
        public Decimal dollarPrice { get; set; }
    }
}
