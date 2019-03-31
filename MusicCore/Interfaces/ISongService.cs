﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MusicCore.Interfaces
{
    public interface ISongService
    {
        Song GetSong(int id);
        List<Song> GetAllSongs();
        Boolean AddSong(Song song);
        Boolean Validate(Song song);
    }
}