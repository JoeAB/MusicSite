using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Entities
{
    public class Artist: IArtist, IDataObject
    {
        public int artistID { get; set; }

        public String name { get; set; }
        public String description { get; set; }

        public DateTime startingDate{ get; set; }
        public DateTime? endingDate { get; set; }

    }
}
