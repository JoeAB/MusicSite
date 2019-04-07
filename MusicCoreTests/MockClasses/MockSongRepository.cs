using MusicData.Entities;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicCoreTests.MockClasses
{
    internal class MockSongRepository : ISongRepository
    {
        List<ISong> songs;

        public MockSongRepository()
        {
            songs = new List<ISong>();
            songs.Add((ISong)new Song()
            {
                songID = 1,
                name = "In the End",
                artistID = 2,
                releaseDate = new DateTime(2000, 10, 24),
                filePath = "It doesn't exist",
                videoPath = "skkskksk",
                genreID = 9001
            });
            songs.Add((ISong)new Song()
            {
                songID = 2,
                name = "Yes or Yes",
                artistID = 1,
                releaseDate = new DateTime(2018, 11, 5),
                filePath = "nope",
                videoPath = "no",
                genreID = 1
            });
        }

        public List<ISong> GetAllSongs()
        {
            return songs;
        }

        public ISong GetByName(string name)
        {
            try
            {
                return songs.Single(x => x.name == name);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public ISong GetSong(int id)
        {
            try
            {
                return songs.Single(x => x.songID == id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool RemoveSong(ISong song)
        {
            try
            {
                songs.Remove(songs.Single(x => x.songID == song.artistID));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveSong(ISong song)
        {
            songs.Add(song);
            return true;
        }

        public List<ISong> SearchByName(string name)
        {
            return songs.FindAll(x => x.name.Contains(name)).ToList();
        }

        public bool UpdateSong(ISong song)
        {
            try
            {
                songs.Remove(songs.Single(x => x.songID == song.songID));
                songs.Add(song);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
