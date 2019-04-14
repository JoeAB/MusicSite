using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicData.Entities
{
    public class SongToAlbumMapping: ISongToAlbumMapping, IDataObject
    {
        [Key]
        public int songToAlbumID { get; set; }

        public int songID{ get; set; }
        public int albumID { get; set; }

    }
}
