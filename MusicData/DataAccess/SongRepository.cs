using MusicData.Entities;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicData.DataAccess
{
    public class SongRepository: ISongRepository
    {
        public bool SaveSong(ISong song)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    context.Songs.Add((Song)song);
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

        public ISong GetSong(int id)
        {
            ISong song;
            try
            {
                using (DataContext context = new DataContext())
                {
                    song = context.Songs.Single(x => x.songID.Equals(id));
                }
            }
            // we had an error and we're going to want to log it
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return song;
        }

        public List<ISong> GetAllSongs()
        {
            List<ISong> songs;
            try
            {
                using (DataContext context = new DataContext())
                {
                    songs = context.Songs.ToList().ConvertAll(x => (ISong)x);
                }
            }
            // we had an error and we're going to want to log it
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return songs;
        }

        public bool UpdateSong(ISong song)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    context.Songs.Update((Song)song);
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

        public bool RemoveSong(ISong song)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    context.Songs.Remove((Song)song);
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

        public ISong GetByName(string name)
        {
            ISong song;
            try
            {
                using (DataContext context = new DataContext())
                {
                    song = context.Songs.Single(x => x.name.Equals(name));
                }
            }
            // we had an error and we're going to want to log it
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return song;
        }

        public List<ISong> SearchByName(string name)
        {
            List<ISong> songs;
            try
            {
                using (DataContext context = new DataContext())
                {
                    songs = context.Songs.Where(x => x.name.Contains(name)).ToList().ConvertAll(x => (ISong)x);
                }
            }
            // we had an error and we're going to want to log it
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return songs;
        }

        public List<ISong> GetSongsByArtist(int artistID)
        {
            List<ISong> songs;
            try
            {
                using (DataContext context = new DataContext())
                {
                    songs = context.Songs.Where(x => x.artistID.Equals(artistID)).ToList().ConvertAll(x => (ISong)x);
                }
            }
            // we had an error and we're going to want to log it
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return songs;
        }
    }
}
