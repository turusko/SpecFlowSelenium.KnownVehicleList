using SpecFlowSelenium.PageObjects.Permits;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Hooks.PermitHooks
{
    [Binding]
    public class SchedulerHooks
    {
        [BeforeFeature("Scheduler")]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureContext.TryGetValue("landingPage", out LandingPage landingPage);
            var lookupPage = landingPage.ClickNext();
            lookupPage.LookupVehicle("ABC123");
            var schedulePage = lookupPage.ConfirmVehicle().ClickContinue();
            featureContext.Add("schedulePage", schedulePage);
        }

        [BeforeScenario("Scheduler")]
        public static void BeforeScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
        {

            featureContext.TryGetValue("schedulePage", out SchedulePage schedulePage);
            scenarioContext.Add("schedulePage", schedulePage);

        }

    }
}