using System;
using System.Collections.Generic;

namespace MusicData.Interfaces
{
    public interface ISongRepository
    {

        ISong GetSong(int id);
        List<ISong> GetAllSongs();
        Boolean SaveSong(ISong Song);
        Boolean RemoveSong(ISong Song);
        Boolean UpdateSong(ISong song);
        ISong GetByName(String name);
        List<ISong> SearchByName(String name);
    }
}
