using MusicData.Entities;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicCoreTests.MockClasses
{
    //Note, I'm not going to mock the the entities, since they are POCO's with no behavior
    internal class MockArtistRepository : IArtistRepository
    {
        List<IArtist> artists;

        public MockArtistRepository()
        {
            artists = new List<IArtist>();
            artists.Add((IArtist)new Artist()
            {
                artistID = 1,
                name = "TWICE",
                description = "Popular K-pop girl group",
                startingDate = new DateTime(2015, 10, 20),
                endingDate = null
            });
            artists.Add((IArtist)new Artist()
            {
                artistID = 2,
                name = "Linkin Park",
                description = "Truly the greatest band in the history of time. Known for great songs such as \"In the End\"",
                startingDate = new DateTime(1996, 1, 1), //1996, is all wikipedia had so lol
                endingDate = null
            });
        }

        public List<IArtist> GetAllArtists()
        {
            return artists;
        }

        public IArtist GetArtist(int id)
        {
            return artists.FirstOrDefault(x => x.artistID == id);
        }

        public IArtist GetByName(string name)
        {
            return artists.FirstOrDefault(x => x.name == name);
        }

        public bool RemoveArtist(IArtist artist)
        {
            try
            {
                artists.Remove(artists.FirstOrDefault(x => x.artistID == artist.artistID));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveArtist(IArtist artist)
        {
            artists.Add(artist);
            return true;
        }

        public List<IArtist> SearchByName(string name)
        {
            return artists.FindAll(x => x.name.Contains(name)).ToList();
        }

        public bool UpdateArtist(IArtist artist)
        {
            try
            {
                artists.Remove(artists.Single(x => x.artistID == artist.artistID));
                artists.Add(artist);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
