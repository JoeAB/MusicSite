using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Interfaces
{
    public interface ISong
    {
        int songID { get; set; }
        IGenre genre { get; set; }
        IArtist artist { get; set; }


        String name { get; set; }
        String filePath { get; set; }
        DateTime releaseDate { get; set; }
    }
}
