using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSelenium.pages
{
    public class ShoppingCartPage
    {
        private readonly IWebDriver driver;
        public ShoppingCartPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        IWebElement QuantityInput => driver.FindElement(By.Id("cart_quantity50"));
        IWebElement RemoveButton => driver.FindElement(By.CssSelector(".btn.btn-sm.btn-default"));
        IWebElement CheckoutButton => driver.FindElement(By.Id("cart_checkout1"));

        IWebElement UnitPrice => driver.FindElements(By.CssSelector("tr td.align_right"))[0];
        IWebElement TotalPrice => driver.FindElements(By.CssSelector("tr td.align_right"))[1];
        
        IWebElement ShoppingCartEmpty => driver.FindElement(By.CssSelector(".contentpanel"));

        public void ChangePositiveQuantity(int quantity)
        {
            QuantityInput.Clear();
            QuantityInput.SendKeys("" + quantity);
            QuantityInput.SendKeys(Keys.Enter);

        }

        public void RemoveProduct()
        {
            RemoveButton.Click();
        }

        public bool ChangePositiveQuantityResult()
        {
            return int.Parse(QuantityInput.GetAttribute("value")) * Convert.ToDouble(UnitPrice.Text.Substring(1)) == Convert.ToDouble(TotalPrice.Text.Substring(1));
        }

        public void ChangeNonPositiveQuantity(int quantity)
        {
            QuantityInput.Clear();
            QuantityInput.SendKeys("" + quantity);
            QuantityInput.SendKeys(Keys.Enter);

        }

        public bool ChangeNonPositiveQuantityResult()
        {
            return ShoppingCartEmpty.Text.Contains("shopping cart is empty");
        }


        public void GoToAccountLoginPage()
        {
            CheckoutButton.Click();
        }







    }
}
