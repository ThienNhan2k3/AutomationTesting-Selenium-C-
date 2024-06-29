using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSelenium.pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver driver;
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            this.RegionSelect = new SelectElement(driver.FindElement(By.Name("zone_id")));
            this.CountrySelect = new SelectElement(driver.FindElement(By.Name("country_id")));
        }

        IWebElement FirstName => driver.FindElement(By.Name("firstname"));
        IWebElement LastName => driver.FindElement(By.Name("lastname"));
        IWebElement Email => driver.FindElement(By.Name("email"));
        IWebElement Address => driver.FindElement(By.Name("address_1"));
        IWebElement City => driver.FindElement(By.Name("city"));
        IWebElement PostCode => driver.FindElement(By.Name("postcode"));

        SelectElement RegionSelect { get; set; }
        SelectElement CountrySelect { get; set; }


        IWebElement ContinueButton => driver.FindElement(By.CssSelector(".btn.btn-orange.pull-right.lock-on-click"));


        public void FillTheForm(string firstName, string lastName, string email, string address, string city, string region, string zip, string country)
        {
            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            Email.SendKeys(email);
            Address.SendKeys(address);
            City.SendKeys(city);
            PostCode.SendKeys(zip);
            CountrySelect.SelectByText(country);
            RegionSelect.SelectByText(region);

        }

        public void GoToCheckoutConfirmPage()
        {
            ContinueButton.Click();
        }




    }
}
