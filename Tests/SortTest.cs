
using TwentyLesson.Pages;

namespace TwentyLesson.Tests
{
    internal class SortTest : BaseTest
    {
        [Test]
        public void SortFromAtoZ()
        {
            LoginPage.Login();
            var answer = ManePage.SortFromAToZOrVersa(0);
            Assert.That(answer, Is.True);
        }
        [Test]
        public void SortFromZtoA()
        {
            LoginPage.Login();
            var answer = ManePage.SortFromAToZOrVersa(1);
            Assert.That(answer, Is.True);
        }

        [Test]
        public void SortFromLowToHigh()
        {
            LoginPage.Login();
            var answer = ManePage.SortFromLowToHighOrVersa(2);
            Assert.That(answer, Is.True);
        }
        [Test]
        public void SortFromHighToLow()
        {
            LoginPage.Login();
            var answer = ManePage.SortFromLowToHighOrVersa(3);
            Assert.That(answer, Is.True);
        }

    }
}
