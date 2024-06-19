
using TwentyLesson.Pages;

namespace TwentyLesson.Tests
{
    internal class CartTest : BaseTest
    {
        [Test]
        public void AddProductToCart()
        {
            LoginPage.Login();
            var answer = ManePage.AddProductToCart();
            Assert.That(answer, Is.True);
        }
        [Test]
        public void RemoveProductFromCart()
        {
            LoginPage.Login();
            var answer = ManePage.RemoveProductFromCart();
            Assert.That(answer, Is.True);
        }
    }
}
