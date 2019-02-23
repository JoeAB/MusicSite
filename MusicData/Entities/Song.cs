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
        public Genre songGenre { get; set; }
        public Artist songArtist { get; set; }

        [NotMapped]
        public IGenre genre
        {
            get
            {
                return songGenre;
            }
            set
            {
            }
        }
        [NotMapped]
        public IArtist artist
        {
            get
            {
                return songArtist;
            }
            set
            {
            }
        }
        public String name { get; set; }
        public String filePath { get; set; }
        public Decimal dollarPrice { get; set; }
        public DateTime releaseDate { get; set; }

    }
}
