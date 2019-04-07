using MusicData.Entities;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicCoreTests.MockClasses
{
    internal class MockGenreRepository : IGenreRepository
    {
        List<IGenre> genres;

        public MockGenreRepository()
        {
            genres = new List<IGenre>();
            genres.Add((IGenre) new Genre()
            {
                genreID = 1,
                name = "K-Pop"
            });
            genres.Add((IGenre)new Genre()
            {
                genreID = 2,
                name = "Death Metal"
            });
            genres.Add((IGenre)new Genre()
            {
                genreID = 3,
                name = "Banjo Music"
            });
        }

        public List<IGenre> GetAllGenres()
        {
            return genres;
        }

        public IGenre GetByName(string name)
        {
            try
            {
                return genres.Single(x => x.name == name);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IGenre GetGenre(int id)
        {
            try
            {
                return genres.Single(x => x.genreID == id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool RemoveGenre(IGenre genre)
        {
            try
            {
                genres.Remove(genres.Single(x => x.genreID == genre.genreID));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveGenre(IGenre genre)
        {
            genres.Add(genre);
            return true;
        }

        public List<IGenre> SearchByName(string name)
        {
            return genres.FindAll(x => x.name.Contains(name)).ToList();
        }

        public bool UpdateGenre(IGenre genre)
        {
            try
            {
                genres.Remove(genres.Single(x => x.genreID == genre.genreID));
                genres.Add(genre);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
