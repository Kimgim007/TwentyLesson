using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TwentyLesson.WebDriver;

namespace TwentyLesson.Pages
{
    internal class BasePage
    {
        protected static IWebDriver driver = Driver.GetDriver();
        protected static WebDriverWait wait = Driver.WaitDriver(driver, 10);

        public static void OpenPage()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
        }
    }
}
