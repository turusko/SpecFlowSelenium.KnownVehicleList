using SpecFlowSelenium.PageObjects.Permits;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Hooks.PermitHooks
{
    [Binding]
    public class ChargePageHooks
    {
        [BeforeFeature("ChargePage")]
        public static void FeatureSetup(FeatureContext featureContext)
        {

            featureContext.TryGetValue("landingPage", out LandingPage landingPage);
            var vehiclePage = landingPage.ClickNext();
            featureContext.Add("vehiclePage", vehiclePage);

        }

        [BeforeScenario("ChargePage")]
        public static void ScenarioSetup(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            featureContext.TryGetValue("vehiclePage", out VehiclePage vehiclePage);
            scenarioContext.Add("vehiclePage", vehiclePage);

        }

        [AfterScenario("ChargePage")]
        public static void ScenarioTearDown(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            scenarioContext.TryGetValue("ChargePage", out ChargePage chargePage);
            chargePage.ReturnToPreviousPage()
             .SearchAgain();

        }

    }
}
