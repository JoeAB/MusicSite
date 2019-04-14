using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Interfaces
{
    public interface ISongToAlbumMapping
    {
        
        int songToAlbumID { get; set; }
        int songID { get; set; }
        int albumID { get; set; }
    }
}
