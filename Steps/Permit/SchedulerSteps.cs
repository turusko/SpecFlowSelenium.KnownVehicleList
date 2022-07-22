using System;
using TechTalk.SpecFlow;

namespace MyNamespace
{
    [Binding]
    public class SchedulerSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public SchedulerSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am to select todays date by default")]
        public void GivenIamtoselecttodaysdatebydefault()
        {
            _scenarioContext.Pending();
        }

        [When(@"i select the plus icon")]
        public void Wheniselecttheplusicon()
        {
            _scenarioContext.Pending();
        }

        [Then(@"the date is added to my basket")]
        public void Thenthedateisaddedtomybasket()
        {
            _scenarioContext.Pending();
        }

    }
}