using Microsoft.EntityFrameworkCore;
using MusicData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.DB
{
    class DataContext: DbContext
    {
        public DataContext()
        {

        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}
