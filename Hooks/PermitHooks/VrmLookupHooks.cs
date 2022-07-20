using SpecFlowSelenium.Drivers;
using SpecFlowSelenium.PageObjects.Permits;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Hooks.PermitHooks
{
    [Binding]
    public class VrmLookupHooks
    {
        [BeforeFeature("VrmLookup")]
        public static void VrmFeatureSetup(FeatureContext featureContext)
        {

            featureContext.TryGetValue("landingPage", out LandingPage landingPage);
            var vehiclePage = landingPage.ClickNext();
            featureContext.Add("vehiclePage", vehiclePage);

        }

        [BeforeScenario("VrmLookup")]
        public static void VrmScenarioSetup(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
           featureContext.TryGetValue("vehiclePage", out VehiclePage vehiclePage);
           scenarioContext.Add("vehiclePage", vehiclePage);

        }


        [AfterScenario("VrmLookup")]
        public static void VrmScenarioTearDown(ScenarioContext scenarioContext)
        {

            scenarioContext.TryGetValue("vehiclePage", out VehiclePage vehiclePage);
            vehiclePage.SearchAgain();

        }

        [AfterFeature("VrmLookup")]
        public static void VrmFeatureTeardown(FeatureContext featureContext)
        {
            featureContext.TryGetValue("webDriver", out Drivers.Driver webDriver);
            webDriver.Close();

        }
    }
}
