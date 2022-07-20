using System;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeFeature("permit")]
        public static void PermitAppSetup(FeatureContext featureContext)
        {
            var driver = new Drivers.Driver();
            var landingPage = driver.NavigateToPermits();
            featureContext.Add("webDriver", driver);
            featureContext.Add("landingPage", landingPage);
        }
    }
}
