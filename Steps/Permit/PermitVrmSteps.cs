using System;
using System.Collections.ObjectModel;
using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowSelenium.PageObjects.Permits;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Steps.Permit
{
    [Binding]
    public class PermitVrmSteps
    {
        private readonly ScenarioContext _scenarioContext;

        private VehiclePage _vehiclePage;

        public PermitVrmSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"user look up (.*)")]
        [Given(@"user look up (.*)")]
        public void Whenuserlooksupvrm(string vrm)
        {
            _scenarioContext.TryGetValue("vehiclePage", out _vehiclePage);
            _scenarioContext.Add("vehicleDetails", _vehiclePage.LookupVehicle(vrm));
        }

        [Then(@"vehicle colour is displayed as (.*)")]
        public void Thenvehiclecolourisdisplayedascolour(string colour)
        {
            _scenarioContext.TryGetValue("vehicleDetails", out ReadOnlyCollection<IWebElement> vehicleDetails);
            vehicleDetails[2].Text.Should().ContainEquivalentOf(colour);
        }

        [Then(@"vehicle make is displayed as (.*)")]
        public void Thenvehiclemakeisdisplayedasmake(string make)
        {
            _scenarioContext.TryGetValue("vehicleDetails", out ReadOnlyCollection<IWebElement> vehicleDetails);
            vehicleDetails[1].Text.Should().ContainEquivalentOf(make);
        }

    }
}