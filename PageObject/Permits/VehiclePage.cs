using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowSelenium.PageObjects.Permits
{
    public class VehiclePage
    {
        private IWebDriver _webDriver;
        public VehiclePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public ReadOnlyCollection<IWebElement> LookupVehicle(string vrm)
        {
            this.EnterVrm(vrm);
            this.ClickFindVehicle();
            this.WaitForProgressButton();
            return _webDriver.FindElements(By.CssSelector(".VehcileDetailine"));


        }
        public void ConfirmVehicle()
        {
            this.WaitForProgressButton().Click();

        }

        private IWebElement WaitForProgressButton()
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(60))
                .Until(c => c.FindElement(By.XPath("//button[text()='Continue']")));

        }

          private IWebElement WaitForVrmBox()
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30))
                .Until(c => c.FindElement(By.CssSelector(".VrmBox")));

        }


        private void EnterVrm(string vrm)
        {
            this.WaitForVrmBox().SendKeys(vrm);
        }

        private void ClickFindVehicle()
        {
            _webDriver.FindElement(By.XPath("//button[text()='Find vehicle']")).Click();
        }
    }
}


// class PermitVehicle:
//     driver: WebDriver

//     def __init__(self, driver) -> None:
//         super().__init__()
//         self.driver = driver

//     def lookup_vrm(self, vrm: str) -> List[WebElement]:
//         self.__enter_vrm(vrm)
//         self.__click_find_vehicle()
//         self.__wait_for_progress_button()
//         return self.driver.find_elements(By.CSS_SELECTOR, ".VehcileDetailine")

//     def confirm_vehicle(self) -> PermitCharge:
//         element = WebDriverWait(self.driver, 20).until(
//             EC.element_to_be_clickable((By.XPATH, '//button[text()="Continue"]')))
//         element.click()
//         return PermitCharge(self.driver)

//     def __wait_for_progress_button(self) -> None:
//         WebDriverWait(self.driver, 60).until(EC.presence_of_element_located((By.XPATH, '//button[text()="Continue"]')))

//     def __enter_vrm(self, vrm: str) -> None:
//         WebDriverWait(self.driver, 30).until(EC.element_to_be_clickable((By.CSS_SELECTOR, ".VrmBox"))).send_keys(vrm)

//     def __click_find_vehicle(self) -> None:
//         WebDriverWait(self.driver, 20).until(
//             EC.element_to_be_clickable((By.XPATH, '//button[text()="Find vehicle"]'))).click()
