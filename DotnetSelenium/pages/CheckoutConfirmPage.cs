using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSelenium.pages
{
    public class CheckoutConfirmPage
    {
        private readonly IWebDriver driver;
        public CheckoutConfirmPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        IWebElement ConfirmOrderButton => driver.FindElement(By.CssSelector(".btn.btn-orange.pull-right.lock-on-click"));
        
        public void ConfirmOrder()
        {
            ConfirmOrderButton.Click();
        }




    }
}
