using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Interfaces
{
    public interface IGenreRepository
    {
        IGenre GetGenre(int id);
        List<IGenre> GetAllGenres();
        Boolean SaveGenre(IGenre genre);
        Boolean RemoveGenre(IGenre genre);
        IGenre GetByName(String name);
        List<IGenre> SearchByName(String name);
    }
}
