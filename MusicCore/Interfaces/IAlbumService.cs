using System;
using System.Collections.Generic;
using System.Text;

namespace MusicCore.Interfaces
{
    public interface IAlbumService
    {
        Album GetAlbum(int id);
        List<Album> GetAllAlbumss();
        Boolean AddAlbum(Album album);
        Boolean Validate(Album album);
    }
}
