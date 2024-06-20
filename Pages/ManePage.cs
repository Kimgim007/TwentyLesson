using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Globalization;
using TwentyLesson.WebDriver;

namespace TwentyLesson.Pages
{
    internal class ManePage : BasePage
    {
        private static IWebElement sortContainer => Driver.WaitDriver(Driver.GetDriver(), 10).Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='header_container']/div[2]/div/span/select")));
        private static IWebElement buttonShoppingCart => Driver.WaitDriver(Driver.GetDriver(), 10).Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='shopping_cart_container']/a")));

        private static List<IWebElement> _AllAddButtons => Driver.WaitDriver(Driver.GetDriver(), 10).Until(driver => driver.FindElements(By.XPath("//*[@class='btn btn_primary btn_small btn_inventory ']"))).ToList();
        private static List<IWebElement> _itemNames => Driver.WaitDriver(Driver.GetDriver(), 10).Until(driver => driver.FindElements(By.XPath("//*[@class='inventory_item_name ']"))).ToList();
        private static List<IWebElement> _itemCosts => Driver.WaitDriver(Driver.GetDriver(), 10).Until(driver => driver.FindElements(By.XPath("//*[@class='inventory_item_price']"))).ToList();


        public static bool AddProductToCart()
        {
            var urlButtonProduct = _AllAddButtons[0];
            urlButtonProduct.Click();
            buttonShoppingCart.Click(); // Эта строчка не обязательна 
            var cartConteentsCount = CartPage.allElementsFromCartConteents.Count;
            if (cartConteentsCount == null && cartConteentsCount == 0)
            {
                return false;
            }
            return true;
        }

        public static bool RemoveProductFromCart()
        {
            if (AddProductToCart())
            {
                var urlButtonRemoveProduct = CartPage.removeButtons[0];
                urlButtonRemoveProduct.Click();

                var allElementsFromCartConteents = Driver.WaitDriver(Driver.GetDriver(), 10).Until(driver => driver.FindElements(By.XPath("//*[@class='cart_item']"))).ToList();
         
                if (allElementsFromCartConteents.Count != 0)
                {
                    return false;
                }
                return true;

            }
            return false;
        }
        //0 - A To Z
        //1 - Z To A
        public static bool SortFromAToZOrVersa(int containerItemNumber)
        {
            IList<IWebElement> sortContainerElements = sortContainer.FindElements(By.XPath("./*"));
            var names = _itemNames.Select(q => q.Text).ToList();
            List<string>? sortNames = new List<string>();

            if (containerItemNumber == 0)
            {
                sortNames = names.OrderBy(names => names).ToList();
            }
            if (containerItemNumber == 1)
            {
                sortNames = names.OrderByDescending(names => names).ToList();
            }

            sortContainerElements[containerItemNumber].Click();

            var itemNames = Driver.WaitDriver(Driver.GetDriver(), 10).Until(driver => driver.FindElements(By.XPath("//*[@class='inventory_item_name ']"))).ToList();
            var namesSortCheck = itemNames.Select(q => q.Text).ToList();

            if (!sortNames.SequenceEqual(namesSortCheck))
            {
                return false;
            }
            return true;
        }

        //2 - Low To High
        //3 - High To Low
        public static bool SortFromLowToHighOrVersa(int containerItemNumber)
        {

            IList<IWebElement> sortContainerElements = sortContainer.FindElements(By.XPath("./*"));

            var costs = _itemCosts.Select(q => Convert.ToDecimal(q.Text.Replace("$", ""), CultureInfo.InvariantCulture)).ToList();
            List<decimal>? sortCosts = new List<decimal>();

            if (containerItemNumber == 2)
            {
                sortCosts = costs.OrderBy(costs => costs).ToList();
            }
            if (containerItemNumber == 3)
            {
                sortCosts = costs.OrderByDescending(costs => costs).ToList();
            }

            sortContainerElements[containerItemNumber].Click();

            var itemCosts = Driver.WaitDriver(Driver.GetDriver(), 10).Until(driver => driver.FindElements(By.XPath("//*[@class='inventory_item_price']"))).ToList();
            var sortCheck = itemCosts.Select(q => Convert.ToDecimal(q.Text.Replace("$", ""), CultureInfo.InvariantCulture)).ToList();

            if (!sortCosts.SequenceEqual(sortCheck))
            {
                return false;
            }
            return true;
        }
    }
}