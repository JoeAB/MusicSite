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

        [Test]
        public void AddAndRemoveArtist()
        {
            driver.Url = HostUrl + "/artist/artists";
            driver.FindElement(By.Name("createLink")).Click();
            String pageTitleActual = driver.Title;

            driver.FindElement(By.Id("artist_name")).SendKeys("Test");
            driver.FindElement(By.Id("artist_description")).SendKeys("Test part 2");
            driver.FindElement(By.Id("artist_startingDate")).SendKeys("2011-01-10");
            driver.FindElement(By.Id("artist_endingDate")).SendKeys("2011-01-11");
            driver.FindElement(By.Id("submit")).Submit();
            var elements = driver.FindElements(By.Name("deleteLink"));
            int countBeforeDelete = elements.Count;
            Assert.AreEqual(elements[elements.Count - 1].GetAttribute("id"), "delete_Test");
            elements[elements.Count - 1].Click();
            int countAfterDelete = driver.FindElements(By.Name("deleteLink")).Count;
            Assert.AreNotEqual(countBeforeDelete, countAfterDelete);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}
