using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Entities
{
    public class Genre: IGenre
    {
        public int genreID { get; set; }

        public String name { get; set; }
    }
}
