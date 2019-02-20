using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicData.Entities
{
    public class SongToAlbumMapping
    {
        [Key]
        public int songToAlbumID { get; set; }

        public Song song{ get; set; }
        public Album album { get; set; }

    }
}
