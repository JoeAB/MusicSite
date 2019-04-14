using MusicData.Entities;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.DataAccess
{
    public class SongToAlbumMappingRepository : ISongToAlbumMappingRepository
    {
        public bool AddSongToAlbumMapping(int albumID, int songID)
        {
            try
            {
                SongToAlbumMapping songToAlbumMapping = new SongToAlbumMapping();
                songToAlbumMapping.albumID = albumID;
                songToAlbumMapping.songID = songID;
                using (DataContext context = new DataContext())
                {
                    context.SongToAlbumMappings.Add(songToAlbumMapping);
                    context.SaveChanges();
                }
            }
            // we had an error and we're going to want to log it
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
