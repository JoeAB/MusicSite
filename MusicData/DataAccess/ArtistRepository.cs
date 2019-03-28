using MusicData.Entities;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
            List<IArtist> artists;
            try
            {
                using (DataContext context = new DataContext())
                {
                    artists = context.Artists.ToList().ConvertAll(x=>(IArtist)x);
                }
            }
            // we had an error and we're going to want to log it
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return artists;
        }

        public bool RemoveArtist(IArtist artist)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    context.Artists.Remove((Artist)artist);
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

        public IArtist GetByName(string name)
        {
            IArtist artist;
            try
            {
                using (DataContext context = new DataContext())
                {
                    artist = context.Artists.Single(x => x.name.Equals(name));
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

        public List<IArtist> SearchByName(string name)
        {
            List<IArtist> artists;
            try
            {
                using (DataContext context = new DataContext())
                {
                    artists = context.Artists.Where(x => x.name.Contains(name)).ToList().ConvertAll(x => (IArtist)x);
                }
            }
            // we had an error and we're going to want to log it
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return artists;
        }
    }
}
