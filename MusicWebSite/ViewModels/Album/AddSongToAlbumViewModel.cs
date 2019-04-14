using MusicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebSite.ViewModels.Album
{
    public class AddSongToAlbumViewModel
    {
        public AlbumModel album { get; set; }
        public int artistID { get; set; }
        public List<ArtistModel> artists { get; set; }
        public int songID { get; set; }
    }
}
