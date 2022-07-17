using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangMan;

namespace UnitTestsHangMan
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestCheckLetter()
        {
            Game instance = new Game();
            string word = "test";
            char letter = 'e';

            var result = instance.checkLetter(word, letter);

            Assert.IsTrue(result);
        }
    }
}
