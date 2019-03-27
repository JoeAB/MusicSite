using MusicData.Entities;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MusicData.DataAccess
{
    public class GenreRepository: IGenreRepository
    {
        public bool SaveGenre(IGenre genre)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    context.Genres.Add((Genre)genre);
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

        public IGenre GetGenre(int id)
        {
            IGenre genre;
            try
            {
                using (DataContext context = new DataContext())
                {
                    genre = context.Genres.Single(x => x.genreID.Equals(id));
                }
            }
            // we had an error and we're going to want to log it
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return genre;
        }

        public List<IGenre> GetAllGenres()
        {
            List<IGenre> genres;
            try
            {
                using (DataContext context = new DataContext())
                {
                    genres = context.Genres.ToList().ConvertAll(x => (IGenre)x);
                }
            }
            // we had an error and we're going to want to log it
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return genres;
        }

        public bool RemoveGenre(IGenre genre)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    context.Genres.Remove((Genre)genre);
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
