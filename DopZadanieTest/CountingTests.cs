using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DopZadanieTest
{
    [TestClass]
    public class CountingTests
    {
        [TestClass]
        public class DopZadanieTests
        {
            [TestMethod]
            public void CountZeros_PassStringWithZeros_CountOfZeros()
            {
                string input = "000dfgdfgdfgrf0wer2342300";
                int expectedOutput = 6;

                int actualOutput = Counting.CountZeros(input);

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }
}
