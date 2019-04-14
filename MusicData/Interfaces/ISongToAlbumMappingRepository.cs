using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Interfaces
{
    public interface ISongToAlbumMappingRepository
    {
        Boolean AddSongToAlbumMapping(int albumID, int songID);
    }
}
