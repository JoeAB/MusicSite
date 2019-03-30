﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.Interfaces
{
    public interface IAlbum
    {
        int albumID { get; set; }
        List<ISong> songs { get; set; }
        String name { get; set; }
        DateTime? releaseDate { get; set; }
    }
}
