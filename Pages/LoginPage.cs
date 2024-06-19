using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
namespace TwentyLesson.Pages
{
    internal class LoginPage : BasePage
    {
        const string login = "standard_user";
        const string password = "secret_sauce";

        private static IWebElement loginField = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='user-name']")));
        private static IWebElement passworField = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='password']")));
        private static IWebElement buttonLogin = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='login-button']")));

        public static void Login()
        {
            loginField.SendKeys(login);
            passworField.SendKeys(password);
            buttonLogin.Click();
        }
    }
}
