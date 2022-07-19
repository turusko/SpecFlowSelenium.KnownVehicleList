using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace SpecFlowSelenium.PageObjects.Permits
{
    public class LandingPage
    {
        private IWebDriver _webDriver;

        public LandingPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IWebElement WaitForTitleToAppear()
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30)).Until(c => c.FindElement(By.CssSelector(".Title")));
        }

        public VehiclePage ClickNext()
        {
            this.WaitForTitleToAppear();
            _webDriver.FindElement(By.CssSelector(".BoxedText")).Click();
            return new VehiclePage(_webDriver);
        }

    }
}