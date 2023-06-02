using NUnit.Framework;
using NUnitTestProject1.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace NUnitTestProject1
{
    public class Tests
    {
        private IWebDriver driver;
        string hubUrl;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;

        [SetUp]
        public void Setup()
        {
            vars = new Dictionary<string, object>();

            hubUrl = "http://localhost:4444/wd/hub";
            driver = LocalDriverFactory.CreateInstance(Enums.BrowserType.Firefox, hubUrl);
            js = (IJavaScriptExecutor)driver;
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        [Parallelizable]
        public void OpenGoogleAndSearch()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("q")).SendKeys("I Want to se this on a remote machine");
        }

        [Test]
        [Parallelizable]
        public void OpenBingAndSearch()
        {
            driver.Navigate().GoToUrl("https://www.bing.com/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("q")).SendKeys("I Want to seee this on a remote machine");
        }

        [Test]
        [Parallelizable]
        public void SearchOnPureSourceCode()
        {
            driver.Navigate().GoToUrl("https://www.puresourcecode.com/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.CssSelector("#simplemodal-container a.modalCloseImg")).Click();
            driver.FindElement(By.CssSelector("#search-2 > #searchform .form-control")).Click();
            driver.FindElement(By.CssSelector("#search-2 > #searchform .form-control")).SendKeys("adminlte");
            driver.FindElement(By.CssSelector("#search-2 > #searchform .btn")).Click();
            js.ExecuteScript("window.scrollTo(0,1929)");
            js.ExecuteScript("window.scrollTo(0,2463)");
            js.ExecuteScript("window.scrollTo(0,1198)");
            js.ExecuteScript("window.scrollTo(0,1037)");
            js.ExecuteScript("window.scrollTo(0,437)");
            driver.FindElement(By.CssSelector(".d-md-flex:nth-child(1) .title > a")).Click();

            var element = driver.FindElement(By.CssSelector(".homebtn"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Perform();
        }

        [Test]
        [Parallelizable]
        public void OpenSTSAndClickAround()
        {
            driver.Navigate().GoToUrl("https://www.sts.co.za/");
            driver.Manage().Window.Maximize();

            System.Threading.Thread.Sleep(3000);

            driver.FindElement(By.CssSelector("#scrollTarget > ul > li:nth-child(6) > a")).Click();

            while (true) {
                driver.FindElement(By.CssSelector("#filter > ul > li:nth-child(2) > a")).Click();
                System.Threading.Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#filter > ul > li:nth-child(3) > a")).Click();
                System.Threading.Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#filter > ul > li:nth-child(4) > a")).Click();
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
