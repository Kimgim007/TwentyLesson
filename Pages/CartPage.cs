using OpenQA.Selenium;
using TwentyLesson.WebDriver;

namespace TwentyLesson.Pages
{
    internal class CartPage : BasePage
    {
        public static List<IWebElement> allElementsFromCartConteents => Driver.WaitDriver(Driver.GetDriver(),10).Until(driver => driver.FindElements(By.XPath("//*[@class='cart_item']"))).ToList();
        public static List<IWebElement> removeButtons => Driver.WaitDriver(Driver.GetDriver(), 10).Until(driver => driver.FindElements(By.XPath("//*[@class='btn btn_secondary btn_small cart_button']"))).ToList();
        
    }
}
