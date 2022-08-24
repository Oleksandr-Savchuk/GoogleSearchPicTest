using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace GoogleSearchPicTest
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _searchfield = By.Name("q");
        private readonly By _searchbutton = By.Name("btnK");

        private const string _input = "Image";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [Test]
        public void Test1()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            var searchField = driver.FindElement(_searchfield);
            searchField.SendKeys(_input);
                    
            var searchButton = driver.FindElement(_searchbutton);
            searchButton.Click();
            
            driver.Navigate().GoToUrl("https://www.google.com/search?q=image&hl=ru&sxsrf=ALiCzsbsPJ5Rqm_CkDGkh5purAIECUsCug:1660805270018&source=lnms&tbm=isch&sa=X&ved=2ahUKEwirgKTh5c_5AhWws4sKHT2rCB8Q_AUoAXoECAEQAw&biw=1920&bih=937&dpr=1");
                       
            Assert.IsTrue(driver.FindElement(By.CssSelector("#yDmH0d > div.T1diZc.KWE8qe > c-wiz > div.mJxzWe")).Displayed);         
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}