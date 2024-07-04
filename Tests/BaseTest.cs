
using TwentyLesson.Pages;
using TwentyLesson.WebDriver;

namespace TwentyLesson.Tests
{
    internal class BaseTest
    {
     
        [SetUp]
        public void Setup()
        {
            BasePage.OpenPage();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.TearDown();
        }

    }
}
