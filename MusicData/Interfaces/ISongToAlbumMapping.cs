using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Interfaces
{
    public interface ISongToAlbumMapping
    {
        
        int songToAlbumID { get; set; }
        ISong songReference { get; set; }
        IAlbum albumReference { get; set; }
    }
}
