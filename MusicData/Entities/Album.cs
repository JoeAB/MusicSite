using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicData.Entities
{
    public class Album : IAlbum, IDataObject
    {
        public int albumID { get; set; }
        public List<Song> albumSongs { get; set; }

        [NotMapped]
        public List<ISong> songs
        {
            get
            {
                return albumSongs.ConvertAll(x => (ISong)x);
            }
            set
            {
            }
        }

        public String name { get; set; }
        public DateTime? releaseDate { get; set; }
    }
}
