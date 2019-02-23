using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Interfaces
{
    public interface ISong
    {
        int songID { get; set; }
        IGenre songGenre { get; set; }
        IArtist songArtist { get; set; }

        String name { get; set; }
        String filePath { get; set; }
        Decimal dollarPrice { get; set; }
        DateTime? releaseDate { get; set; }
    }
}
