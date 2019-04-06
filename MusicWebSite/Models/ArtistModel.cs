using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebSite.Models
{
    public class ArtistModel
    {
        public int id { get; set; }

        public String name { get; set; }
        public String description { get; set; }
        public DateTime startingDate { get; set; }
        public DateTime? endingDate { get; set; }

    }
}
