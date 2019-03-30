using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Interfaces
{
    public interface IAlbumRepository
    {
        IAlbum GetAlbum(int id);
        List<IAlbum> GetAllAlbums();
        Boolean SaveAlbum(IAlbum album);
        Boolean RemoveAlbum(IAlbum album);
        IAlbum GetByName(String name);
        List<IAlbum> SearchByName(String name);
    }
}
