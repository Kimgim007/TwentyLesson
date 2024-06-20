using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TwentyLesson.WebDriver;

namespace TwentyLesson.Pages
{
    internal class BasePage
    {   
        public static void OpenPage()
        {
            Driver.GetDriver().Navigate().GoToUrl("https://www.saucedemo.com");
        }
    }
}
