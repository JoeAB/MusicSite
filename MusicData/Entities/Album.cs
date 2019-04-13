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

        public String name { get; set; }
        public DateTime? releaseDate { get; set; }
        public String albumImagePath { get; set; }
    }
}
