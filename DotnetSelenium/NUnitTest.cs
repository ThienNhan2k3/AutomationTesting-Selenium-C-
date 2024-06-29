using DotnetSelenium.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSelenium
{
    public class NUnitTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://automationteststore.com/");
            _driver.Manage().Window.Maximize();
        }



        [Test]
        public void AddProductToCart()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.AddProductsToCart();

            Assert.IsTrue(homePage.AddProductsToCartResult());
        }


        [Test]
        public void IncreaseQuantityOfProduct()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.AddProductsToCart();

            homePage.GoToShoppingCart();

            ShoppingCartPage shoppingCartPage = new ShoppingCartPage(_driver);
            shoppingCartPage.ChangePositiveQuantity(10);
            Assert.IsTrue(shoppingCartPage.ChangePositiveQuantityResult());

        }

        [Test]
        public void DecreaseQuantityOfProduct()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.AddProductsToCart();

            homePage.GoToShoppingCart();

            ShoppingCartPage shoppingCartPage = new ShoppingCartPage(_driver);
            shoppingCartPage.ChangeNonPositiveQuantity(-1);
            Assert.IsTrue(shoppingCartPage.ChangeNonPositiveQuantityResult());

        }


        [Test]
        public void RemoveProductFromCart()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.AddProductsToCart();

            homePage.GoToShoppingCart();

            ShoppingCartPage shoppingCartPage = new ShoppingCartPage(_driver);
            shoppingCartPage.RemoveProduct();
            Assert.IsTrue(shoppingCartPage.ChangeNonPositiveQuantityResult());

        }


        [Test]
        [TestCase("Nhan", "Nguyen", "example@gmail.com", "247 sdfasd", "Devon", "Devon", "123", "United Kingdom")]
        public void OrderProduct(string firstName, string lastName, string email, string address, string city, string region, string zip, string country)
        {
            HomePage homePage = new HomePage(_driver);
            homePage.AddProductsToCart();

            homePage.GoToShoppingCart();

            ShoppingCartPage shoppingCartPage = new ShoppingCartPage(_driver);
            shoppingCartPage.GoToAccountLoginPage();

            AccountLoginPage accountLoginPage = new AccountLoginPage(_driver);
            accountLoginPage.ChooseGuestCheckout();
            accountLoginPage.GoToCheckoutPage();

            CheckoutPage checkoutPage = new CheckoutPage(_driver);
            checkoutPage.FillTheForm(firstName, lastName, email, address, city, region, zip, country);
            checkoutPage.GoToCheckoutConfirmPage();

            CheckoutConfirmPage checkoutConfirmPage = new CheckoutConfirmPage(_driver);
            checkoutConfirmPage.ConfirmOrder();

            ResultOrderPage resultOrderPage = new ResultOrderPage(_driver);
            Assert.IsTrue(resultOrderPage.ConfirmOrderResult());

        }



        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}
