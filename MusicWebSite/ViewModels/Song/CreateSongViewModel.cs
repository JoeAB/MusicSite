using MusicWebSite.Models;
using System.Collections.Generic;


namespace MusicWebSite.ViewModels.Song
{
    public class CreateSongViewModel
    {
        public SongModel song { get; set; }
        public List<GenreModel> genreList {get; set; }
        public int artistID { get; set; }
        public int genreID { get; set; }
    }
}
