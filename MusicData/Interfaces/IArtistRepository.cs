using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Interfaces
{
    public interface IArtistRepository
    {
        IArtist GetArtist(int id);
        List<IArtist> GetAllArtists();
        Boolean UpdateArtist(IArtist artist);
        Boolean SaveArtist(IArtist artist);
        Boolean RemoveArtist(IArtist artist);
        IArtist GetByName(String name);
        List<IArtist> SearchByName(String name);
    }
}
