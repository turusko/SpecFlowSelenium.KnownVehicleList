using System;
using OpenQA.Selenium.Chrome;
using SpecFlowSelenium.PageObjects.Permits;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowSelenium.Drivers
{
    public class Driver
    {
        private ChromeDriver _webDriver;

        public Driver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();

        }

        public LandingPage NavigateToPermits()
        {
            _webDriver.Navigate().GoToUrl("https://identityqa.xrxpsc.com/01/shared/kvl_permits");
            return new LandingPage(_webDriver);
        }

        public void Close()
        {
            _webDriver.Quit();
        }

    }
}
