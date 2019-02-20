using Microsoft.EntityFrameworkCore;
using MusicData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.DB
{
    public class DataContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder .IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Music;Trusted_Connection=True;");
            }
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<SongToAlbumMapping> SongToAlbumMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Artist>().HasData(
                new Artist
                {
                    artistID = 1,
                    name = "TWICE",
                    description = "Popular K-pop girl group",
                    startingDate = new DateTime(2015, 10, 20),
                    endingDate = null
                }
            );
        }
    }
}
