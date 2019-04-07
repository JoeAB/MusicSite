using MusicCore;
using MusicCore.Services;
using MusicCoreTests.MockClasses;
using MusicData.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MusicCoreTests.Tests
{
    public class GenreTests
    {
        private IGenreRepository _genreRepository;

        [SetUp]
        public void Setup()
        {
            _genreRepository = (IGenreRepository)new MockGenreRepository();
        }

        [Test]
        public void ValidateGenreSuccessTest()
        {
            GenreService service = new GenreService(_genreRepository);
            Genre genre = new Genre()
            {
                id = 4,
                name = "Dubstep"
            };
            bool returnValue = service.Validate(genre);
            Assert.IsTrue(returnValue);
        }

        [Test]
        public void ValidateGenreFailureTest()
        {
            GenreService service = new GenreService(_genreRepository);
            Genre genre = new Genre()
            {
                id = 5,
                name = "K-Pop"
            };
            bool returnValue = service.Validate(genre);
            Assert.IsFalse(returnValue);
        }

        [Test]
        public void GetGenreTest()
        {
            String expectedName = "Death Metal";

            GenreService service = new GenreService(_genreRepository);
            Genre genre = service.GetGenre(2);
            Assert.AreEqual(expectedName, genre.name);
        }

        [Test]
        public void GetGenresTest()
        {
            int expectedCount = 3;

            GenreService service = new GenreService(_genreRepository);
            List<Genre> artists = service.GetAllGenres();
            Assert.AreEqual(expectedCount, artists.Count);
        }

        [Test]
        public void AddGenreTest()
        {
            int expectedCount = 4;

            Genre genre = new Genre()
            {
                id = 4,
                name = "Trance"
            };

            GenreService service = new GenreService(_genreRepository);
            service.AddGenre(genre);
            List<Genre> genres = service.GetAllGenres();
            Assert.AreEqual(expectedCount, genres.Count);
        }

        [Test]
        public void UpdateGenreTest()
        {
            GenreService service = new GenreService(_genreRepository);
            Genre genre = new Genre()
            {
                id = 2,
                name = "Classical Death Metal",

            };
            bool returnValue = service.UpdateGenre(genre);
            Assert.IsTrue(returnValue);
        }

    }
}
