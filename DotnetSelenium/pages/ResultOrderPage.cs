using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSelenium.pages
{
    public class ResultOrderPage
    {
        private readonly IWebDriver driver;
        public ResultOrderPage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            this.ConfirmOrderButton = wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".maintext")));

        }


        IWebElement ConfirmOrderButton { get; set; }

        public bool ConfirmOrderResult()
        {
            return ConfirmOrderButton.Displayed == true;
        }




    }
}
