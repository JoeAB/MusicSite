using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicData.Entities
{
    public class Song : ISong, IDataObject
    {
        public int songID { get; set; }
        public int genreID { get; set; }
        public int artistID { get; set; }
        public String name { get; set; }
        public String filePath { get; set; }
        public String videoPath { get; set; }
        public DateTime releaseDate { get; set; }

    }
}
