using MusicCore;
using MusicCore.Services;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetArtistTest()
        {
            ArtistService service = new ArtistService();
            Artist artist = service.GetArtist(1);
            Console.WriteLine("Test result: "+artist.name + " " + artist.description);
            Assert.Pass();
        }
    }
}