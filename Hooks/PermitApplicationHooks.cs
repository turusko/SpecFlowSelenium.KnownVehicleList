using System;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Hooks
{
    [Binding]
    public class PermitApplicationHooks
    {
        [BeforeScenario("VrmLookup")]
        public static void VrmScenarioSetup(ScenarioContext scenarioContext)
        {
            var driver = new Drivers.Driver();
            var vehiclePage = driver.NavigateToPermits()
                .ClickNext();
            
            scenarioContext.Add("webDriver", driver);
            scenarioContext.Add("vehiclePage", vehiclePage);
            
        }

        [AfterScenario("VrmLookup")]
        public static void VrmScenarioTearDown(ScenarioContext scenarioContext)
        {
            scenarioContext.TryGetValue("webDriver", out Drivers.Driver webDriver);
            webDriver.Close();
        }
    }
}
