using MusicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebSite.ViewModels.Album
{
    public class ViewAlbumViewModel
    {
        public AlbumModel album { get; set; }
        public List<SongModel> songs { get; set; }
    }
}
