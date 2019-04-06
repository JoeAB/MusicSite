using MusicWebSite.Models;
using System.Collections.Generic;

namespace MusicWebSite.ViewModels.Song
{
    public class EditSongViewModel
    {
        public SongModel song { get; set; }
        public List<GenreModel> genreList { get; set; }
    }
}
