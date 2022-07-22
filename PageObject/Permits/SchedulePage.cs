using System;
using System.Linq;
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

        public bool IsDateListedInBasket(DateTime date)
        {
            var dateList = _webDriver.FindElements(By.CssSelector(".c-split-content__form-group"));


            foreach (var item in dateList.Skip(1))
            {
                if (item.Text.Contains(date.ToString("ddd MMM yy")))
                {
                    return true;
                }
            }

            return false;

        }

    }
}