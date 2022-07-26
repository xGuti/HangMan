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
            string word = "test";
            Game instance = new Game(word);
            char letter = 'e';

            var result = instance.CheckLetter(letter);

            Assert.IsTrue(result);
        }
    }
}
