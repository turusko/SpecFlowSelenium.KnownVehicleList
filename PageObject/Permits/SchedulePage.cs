using System;
using OpenQA.Selenium;

namespace SpecFlowSelenium.PageObjects.Permits
{
    public class SchedulePage
    {
        private IWebDriver _webDriver;

        public SchedulePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void ClickDate(DateTime date)
        {
            string selector = "td[title='" + date.ToString("D") + "']";
            _webDriver.FindElement(By.CssSelector(selector)).Click();
        }

        public void ClickPlusIcon()
        {
            _webDriver.FindElement(By.CssSelector("button[aria-label='add days button']")).Click();
        }

    }
}