using System;
using System.Collections.Generic;
using System.Text;

namespace MusicCore.Interfaces
{
    public interface IAlbumService
    {
        Album GetAlbum(int id);
        List<Album> GetAllAlbums();
        Boolean AddAlbum(Album album);
        Boolean Validate(Album album);
    }
}
