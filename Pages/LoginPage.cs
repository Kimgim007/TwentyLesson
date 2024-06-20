using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TwentyLesson.WebDriver;
namespace TwentyLesson.Pages
{
    internal class LoginPage : BasePage
    {
        const string login = "standard_user";
        const string password = "secret_sauce";

        private static IWebElement loginField => Driver.WaitDriver(Driver.GetDriver(), 10).Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='user-name']")));
        private static IWebElement passworField => Driver.WaitDriver(Driver.GetDriver(), 10).Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='password']")));
        private static IWebElement buttonLogin => Driver.WaitDriver(Driver.GetDriver(), 10).Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='login-button']")));

        public static void Login()
        {
            loginField.SendKeys(login);
            passworField.SendKeys(password);
            buttonLogin.Click();
        }
    }
}
