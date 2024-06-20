using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace TwentyLesson.WebDriver
{
    internal class Driver
    {
        private static IWebDriver? _driver;
        private static WebDriverWait? _wait;

        public static IWebDriver GetDriver()
        {
            if(_driver == null)
            {
                _driver = new ChromeDriver();
            }
            return _driver;
        }

        public static WebDriverWait WaitDriver(IWebDriver driver, double timeSpan)
        {
            if(_wait == null)
            {
                _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            }
            return _wait;
        }

        public static void TearDown()
        {
            _driver.Quit();
            _driver = null;
            _wait = null;
        }
    }
}
