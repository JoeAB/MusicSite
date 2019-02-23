using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicData.Entities
{
    public class SongToAlbumMapping: ISongToAlbumMapping
    {
        [Key]
        public int songToAlbumID { get; set; }

        public ISong song{ get; set; }
        public IAlbum album { get; set; }

    }
}
