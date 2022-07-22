
using System;
using FluentAssertions;
using SpecFlowSelenium.PageObjects.Permits;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Steps.Permit
{
    [Binding]
    public class ChageSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private VehiclePage _vehiclePage;
        private ChargePage _chargePage;

        public ChageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _scenarioContext.TryGetValue("vehiclePage", out _vehiclePage);

        }

        [When(@"user proceeds to charge page")]
        public void Whenuserproceedstochargepage()
        {
            _chargePage = _vehiclePage.ConfirmVehicle();
            _scenarioContext.Add("ChargePage", _chargePage);
        }

        [Then(@"the charge of the vehicle is £(.*)")]
        public void Thenthechargeofthevehicleis(int chargeAmount)
        {
            _chargePage.GetChargeAmount().Should().Be(chargeAmount);
        }


        [Then(@"Charge Name is (.*)")]
        public void ThenChargeNameisname(string chargeName)
        {
            _chargePage.IsChargeNamePresent(chargeName).Should().Be(true);
        }


    }
}