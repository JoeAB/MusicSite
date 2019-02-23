using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Interfaces
{
    public interface ISongToAlbumMapping
    {
        
        int songToAlbumID { get; set; }

        ISong song { get; set; }
        IAlbum album { get; set; }
    }
}
