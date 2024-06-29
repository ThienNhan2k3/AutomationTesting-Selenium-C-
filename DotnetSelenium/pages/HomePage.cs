using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DotnetSelenium.pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        public HomePage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        IWebElement AddToCardProduct1 => driver.FindElements(By.ClassName("productcart"))[0];

        IWebElement PriceTagProduct1 => driver.FindElements(By.ClassName("pricetag"))[0];


        IWebElement ItemQuantity => driver.FindElement(By.CssSelector(".dropdown.hover .fa-shopping-cart ~ .label"));

        IWebElement CartLink => driver.FindElement(By.CssSelector(".dropdown .fa-shopping-cart"));


        public void GoToShoppingCart()
        {
            MoveToElement(CartLink);
            CartLink.Click();
        }


        public void MoveToElement(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public void AddProductsToCart()
        {
            MoveToElement(AddToCardProduct1);
            AddToCardProduct1.Click();

        }

        public bool AddProductsToCartResult()
        {
            return ItemQuantity.Text == "1";
        }

        
    }
}
