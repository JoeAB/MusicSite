using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using NUnit.Framework;
using System;
using System.Text;

namespace MusicWebSiteTests
{
    public class Tests
    {
        String HostUrl;
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            //This can be run locally by hitting right click on the Music Web Site project, View, View in Browser
            //then by running the tests here. 
            HostUrl = "https://localhost:44367";
            
            driver = new EdgeDriver("C:\\");
        }

        [Test]
        public void GetArtistTest()
        {

            driver.Url = HostUrl+"/artist/artists";
            String pageTitleActual = driver.Title;
            String pageTitleExpected = "Artists - MusicWebSite";

            Assert.AreEqual(pageTitleExpected, pageTitleActual);

        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}
