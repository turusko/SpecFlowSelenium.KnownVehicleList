using System;
using System.Linq;
using FluentAssertions;
using SpecFlowSelenium.PageObjects.Permits;
using TechTalk.SpecFlow;

namespace MyNamespace
{
    [Binding]
    public class SchedulerSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private SchedulePage _schedulePage;

        public SchedulerSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _scenarioContext.TryGetValue("schedulePage", out _schedulePage);
        }

        [Given(@"I am to select todays date by default")]
        public void GivenIamtoselecttodaysdatebydefault()
        {
            
                var listOfSelectedDates = _schedulePage.GetSelectedDates();

                listOfSelectedDates.Should().HaveCount(1);
                listOfSelectedDates.First().GetAttribute("title").Should().Contain(DateTime.Now.ToString("dddd, MMMM d, yyyy"));
       
        }

        [When(@"i select the plus icon")]
        public void Wheniselecttheplusicon()
        {
            _schedulePage.ClickPlusIcon();
        }

        [Then(@"the date is added to my basket")]
        public void Thenthedateisaddedtomybasket()
        {
            _schedulePage.IsDateListedInBasket(DateTime.Now).Should().BeTrue();
        }

    }
}