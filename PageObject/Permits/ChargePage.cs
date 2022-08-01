using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace SpecFlowSelenium.PageObjects.Permits
{
    public class ChargePage
    {
        private IWebDriver _webDriver;

        public ChargePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public int GetChargeAmount()
        {
            foreach (WebElement paragraph in _webDriver.FindElements(By.TagName("p")))
            {
                if (paragraph.Text.Contains("Standard charge per day"))
                {
                    string output = string.Empty;
                    var matches = Regex.Matches(paragraph.Text, @"\d+");

                    foreach (var match in matches)
                    {
                        output += match;
                    }

                    return int.Parse(output) / 100;
                }
            }

            return 0;
        }

        public VehiclePage ReturnToPreviousPage()
        {
            _webDriver.FindElement(By.CssSelector(".c-breadcrumb__link")).Click();
            return new VehiclePage(_webDriver);
        }

        public bool IsChargeNamePresent(string chargeName)
        {
            foreach (WebElement paragraph in _webDriver.FindElements(By.TagName("p")))
            {
                if (paragraph.Text.ToLower().Contains(chargeName.ToLower()))
                {
                    return true;
                }
            }

            return false;

        }

        public SchedulePage ClickContinue()
        {
            _webDriver.FindElement(By.XPath("//button[text()='Select your travel dates']")).Click();
            return new SchedulePage(_webDriver);
        }
    }
}
