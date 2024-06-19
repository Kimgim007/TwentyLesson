using OpenQA.Selenium;

namespace TwentyLesson.Pages
{
    internal class CartPage : BasePage
    {
        public static List<IWebElement> allElementsFromCartConteents = wait.Until(driver => driver.FindElements(By.XPath("//*[@class='cart_item']"))).ToList();
        public static List<IWebElement> removeButtons = wait.Until(driver => driver.FindElements(By.XPath("//*[@class='btn btn_secondary btn_small cart_button']"))).ToList();
    }
}
