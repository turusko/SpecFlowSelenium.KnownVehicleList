using System;
using SpecFlowSelenium.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeFeature("Permit")]
        public static void PermitAppSetup(FeatureContext featureContext)
        {
            var driver = new Drivers.Driver();
            var landingPage = driver.NavigateToPermits();
            featureContext.Add("webDriver", driver);
            featureContext.Add("landingPage", landingPage);
        }

        [AfterFeature("Permit")]
        public static void TearDown(FeatureContext featureContext)
        {
            featureContext.TryGetValue("webDriver", out Driver webDriver);
            webDriver.Close();
        }
    }
}
