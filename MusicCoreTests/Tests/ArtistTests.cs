using MusicCore;
using MusicCore.Services;
using MusicCoreTests.MockClasses;
using MusicData.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MusicCoreTests.Tests
{
    public class ArtistTests
    {
        private IArtistRepository _artistRepository;

        [SetUp]
        public void Setup()
        {
            _artistRepository = (IArtistRepository)new MockArtistRepository();
        }

        [Test]
        public void ValidateArtistSuccessCaseDateSetTest()
        {
            ArtistService service = new ArtistService(_artistRepository);
            Artist artist = new Artist()
            {
                id = 4,
                name = "Johnny Cash",
                description = "And it burns burns burns burns the ring of fire",
                startingDate = new DateTime(1955, 5, 21),
                endingDate = new DateTime(2003, 9, 12)
            };
            bool returnValue = service.Validate(artist);
            Assert.IsTrue(returnValue);
        }

        [Test]
        public void ValidateArtistSuccessCaseNoDateSetTest()
        {
            ArtistService service = new ArtistService(_artistRepository);
            Artist artist = new Artist()
            {
                id = 5,
                name = "Kanye West",
                description = "Thank you Kanye, very cool!",
                startingDate = new DateTime(1996, 1, 1),
                endingDate = null
            };
            bool returnValue = service.Validate(artist);
            Assert.IsTrue(returnValue);
        }


        [Test]
        public void ValidateArtistTestFailureCase()
        {
            ArtistService service = new ArtistService(_artistRepository);
            Artist artist = new Artist()
            {
                id = 6,
                name = "Joe Bennett",
                description = "Me making my music day view",
                startingDate = new DateTime(2020, 1, 1),
                endingDate = new DateTime(2017, 1, 1)
            };
            bool returnValue = service.Validate(artist);
            //or not because these dates make no sense so validation should stop me from making a fool of myself
            Assert.IsFalse(returnValue);
        }

        [Test]
        public void GetArtistTest()
        {
            String expectedName = "TWICE";

            ArtistService service = new ArtistService(_artistRepository);
            Artist artist = service.GetArtist(1);
            Assert.AreEqual(expectedName, artist.name);
        }

        [Test]
        public void GetArtistsTest()
        {
            int expectedCount = 3;

            ArtistService service = new ArtistService(_artistRepository);
            List<Artist> artists = service.GetAllArtists();
            Assert.AreEqual(expectedCount, artists.Count);
        }

        [Test]
        public void AddArtistTest()
        {
            Artist artist = new Artist()
            {
                id = 3,
                name = "Justin Bieber",
                description = "No description needed",
                startingDate = new DateTime(2007, 1, 1),
                endingDate = null
            };

            ArtistService service = new ArtistService(_artistRepository);
            bool returnValue = service.AddArtist(artist);
            Assert.IsTrue(returnValue);
        }

        [Test]
        public void UpdateArtistTest()
        {
            ArtistService service = new ArtistService(_artistRepository);
            Artist artist = new Artist()
            {
                id = 2,
                name = "Linkin Park",
                description = "No description needed",
                startingDate = new DateTime(2007, 1, 1),
                endingDate = new DateTime(2020, 1, 1)
            };
            bool returnValue = service.UpdateArtist(artist);
            Assert.IsTrue(returnValue);
        }
        [Test]
        public void RemoveArtistTest()
        {
            ArtistService service = new ArtistService(_artistRepository);
            bool returnValue = service.RemoveArtist(999);
            Assert.IsTrue(returnValue);
        }
    }
}