using MusicCore;
using MusicCore.Services;
using MusicCoreTests.MockClasses;
using MusicData.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MusicCoreTests.Tests
{
    public class SongTests
    {
        private ISongRepository _songRepository;
        private IArtistRepository _artistRepository;
        private IGenreRepository _genreRepository;

        [SetUp]
        public void Setup()
        {
            _songRepository = (ISongRepository)new MockSongRepository();
            _artistRepository = (IArtistRepository)new MockArtistRepository();
            _genreRepository = (IGenreRepository)new MockGenreRepository();

        }

        [Test]
        public void ValidateArtistSuccessCaseNoAlbumTest()
        {
            Song song = new Song()
            {
                id = 3,
                name = "What is Love?",
                releaseDate = new DateTime(2018, 4, 9),
                filePath = "not here",
                videoPath = "testing",
                songArtistID = 1,
                songGenreID = 1
            };

            SongService service = new SongService(_songRepository, _artistRepository, _genreRepository);
            bool result = service.Validate(song);
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateArtistFailureCaseBadArtistTest()
        {
            Song song = new Song()
            {
                id = 4,
                name = "All Star",
                releaseDate = new DateTime(1999, 5, 4),
                filePath = "not here",
                videoPath = "testing",
                songArtistID = 100,
                songGenreID = 2 //I don't think this was death metal, but let's ignore that for now...
            };

            SongService service = new SongService(_songRepository, _artistRepository, _genreRepository);
            bool result = service.Validate(song);
            Assert.IsFalse(result);
        }
    }
}
