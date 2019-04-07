using System;
using System.Collections.Generic;
using System.Text;

namespace MusicCore.Interfaces
{
    public interface IArtistService
    {
        Artist GetArtist(int id);
        List<Artist> GetAllArtists();
        Boolean UpdateArtist(Artist artist);
        Boolean AddArtist(Artist artist);
        Boolean Validate(Artist artist);
    }
}
