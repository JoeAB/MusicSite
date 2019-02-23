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

        public Song song{ get; set; }
        public Album album { get; set; }

        [NotMapped]
        public ISong songReference
        {
            get
            {
                return song;
            }
            set
            {

            }
        }
        [NotMapped]
        public IAlbum albumReference
        {
            get
            {
                return album;
            }
            set
            {
            }
        }

    }
}
