using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicData.Interfaces
{
    public interface ISong
    {
        int songID { get; set; }
        [ForeignKey("Genres")]
        int genreID { get; set; }
        [ForeignKey("Artists")]
        int artistID { get; set; }


        String name { get; set; }
        String filePath { get; set; }
        DateTime releaseDate { get; set; }
    }
}
