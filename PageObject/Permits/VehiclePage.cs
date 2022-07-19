using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowSelenium.PageObjects.Permits
{
    public class VehiclePage
    {
        private IWebDriver _webDriver;
        public VehiclePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public ReadOnlyCollection<IWebElement> LookupVehicle(string vrm)
        {
            this.EnterVrm(vrm);
            this.ClickFindVehicle();
            this.WaitForProgressButton();
            return _webDriver.FindElements(By.CssSelector(".VehcileDetailine"));


        }
        public void ConfirmVehicle()
        {
            this.WaitForProgressButton().Click();

        }

        public void SearchAgain()
        {
            _webDriver.FindElement(By.Id("no")).Click();
        }

        private IWebElement WaitForProgressButton()
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(60))
                .Until(c => c.FindElement(By.XPath("//button[text()='Continue']")));

        }

          private IWebElement WaitForVrmBox()
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30))
                .Until(c => c.FindElement(By.CssSelector(".VrmBox")));

        }


        private void EnterVrm(string vrm)
        {
            this.WaitForVrmBox().SendKeys(vrm);
        }

        private void ClickFindVehicle()
        {
            _webDriver.FindElement(By.XPath("//button[text()='Find vehicle']")).Click();
        }
        
    }
}

