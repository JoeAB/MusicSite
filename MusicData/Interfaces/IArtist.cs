using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Interfaces
{
    public interface IArtist
    {
        int artistID { get; set; }

        String name { get; set; }
        String description { get; set; }

        DateTime startingDate { get; set; }
        DateTime? endingDate { get; set; }
    }
}
