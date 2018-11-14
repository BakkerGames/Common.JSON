using Common.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Common.JSON
{
    [TestClass]
    public class UnitTestParse
    {
        [TestMethod]
        public void TestJBaseParseJArrayEmpty()
        {
            object testObj = JBase.Parse("[]");
            Assert.AreEqual(testObj.ToString(), "[]");
        }

        [TestMethod]
        public void TestJBaseParseJArrayExtraCommas()
        {
            object testObj = JBase.Parse("[ , , , ]");
            Assert.AreEqual(testObj.ToString(), "[]");
        }

        [TestMethod]
        public void TestJBaseParseJObjectEmpty()
        {
            object testObj = JBase.Parse("{}");
            Assert.AreEqual(testObj.ToString(), "{}");
        }

        [TestMethod]
        public void TestJBaseParseJObjectExtraCommas()
        {
            object testObj = JBase.Parse("{ , , , }");
            Assert.AreEqual(testObj.ToString(), "{}");
        }
    }
}
