using MusicWebSite.Models;
namespace MusicWebSite.ViewModels.Song
{
    public class ViewSongViewModel
    {
        public SongModel song { get; set; }
        public ArtistModel songArtist { get; set; }
        public GenreModel songGenre { get; set; }
    }
}
