using System;
using System.Collections.Generic;

namespace MusicCore.Interfaces
{
    public interface IGenreService
    {
        Genre GetGenre(int id);
        List<Genre> GetAllGenres();
        Boolean AddGenre(Genre genre);
        Boolean Validate(Genre genre);
    }
}
