using MusicData.Entities;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicData.DataAccess
{
    public class ArtistRepository : IArtistRepository
    {
        public bool SaveArtist(IArtist artist)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    context.Artists.Add((Artist)artist);
                    context.SaveChanges();
                }
            }
            // we had an error and we're going to want to log it
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public IArtist GetArtist(int id)
        {
            IArtist artist;
            try
            {
                using (DataContext context = new DataContext())
                {
                    artist = context.Artists.Single(x => x.artistID.Equals(id));
                }
            }
            // we had an error and we're going to want to log it
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return artist;
        }

        public List<IArtist> GetAllArtists()
        {
            throw new NotImplementedException();
        }

        public bool RemoveArtist(IArtist artist)
        {
            throw new NotImplementedException();
        }
    }
}
