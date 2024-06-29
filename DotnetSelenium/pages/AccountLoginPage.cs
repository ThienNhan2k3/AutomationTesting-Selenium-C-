using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSelenium.pages
{
    public class AccountLoginPage
    {
        private readonly IWebDriver driver;
        public AccountLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        IWebElement GuestCheckout => driver.FindElement(By.Id("accountFrm_accountguest"));
        IWebElement ContinueButton => driver.FindElement(By.CssSelector(".btn.btn-orange.pull-right"));

        public void ChooseGuestCheckout()
        {
            GuestCheckout.Click();
        }

        public void GoToCheckoutPage()
        {
            ContinueButton.Click();
        }

    }
}
