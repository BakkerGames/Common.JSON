using Common.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Common.JSON
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNewJArray()
        {
            JArray testObj = new JArray();
            Assert.IsNotNull(testObj);
        }

        [TestMethod]
        public void TestNewJArrayToString()
        {
            JArray testObj = new JArray();
            Assert.AreEqual(testObj.ToString(), "[]");
        }

        [TestMethod]
        public void TestNewJArrayToStringNone()
        {
            JArray testObj = new JArray();
            Assert.AreEqual(testObj.ToString(JsonFormat.None), "[]");
        }

        [TestMethod]
        public void TestNewJArrayToStringIndent()
        {
            JArray testObj = new JArray();
            Assert.AreEqual(testObj.ToString(JsonFormat.Indent), "[]");
        }

        [TestMethod]
        public void TestNewJArrayToStringOneItemNum()
        {
            JArray testObj = new JArray();
            testObj.Add(123);
            Assert.AreEqual(testObj.ToString(JsonFormat.None), "[123]");
        }

        [TestMethod]
        public void TestNewJObject()
        {
            JObject testObj = new JObject();
            Assert.IsNotNull(testObj);
        }

        [TestMethod]
        public void TestNewJObjectToString()
        {
            JObject testObj = new JObject();
            Assert.AreEqual(testObj.ToString(), "{}");
        }

        [TestMethod]
        public void TestNewJObjectToStringNone()
        {
            JObject testObj = new JObject();
            Assert.AreEqual(testObj.ToString(JsonFormat.None), "{}");
        }

        [TestMethod]
        public void TestNewJObjectToStringIndent()
        {
            JObject testObj = new JObject();
            Assert.AreEqual(testObj.ToString(JsonFormat.Indent), "{}");
        }

        [TestMethod]
        public void TestNewJObjectToStringOneItemNum()
        {
            JObject testObj = new JObject();
            testObj.Add("Hello", 123);
            Assert.AreEqual(testObj.ToString(), "{\"Hello\":123}");
        }

        [TestMethod]
        public void TestNewJObjectToStringOneItemNumIndent()
        {
            JObject testObj = new JObject();
            testObj.Add("Hello", 123);
            Assert.AreEqual(testObj.ToString(JsonFormat.Indent), "{\r\n  \"Hello\": 123\r\n}");
        }

        [TestMethod]
        public void TestNewJObjectToStringTwoItemNum()
        {
            JObject testObj = new JObject();
            testObj.Add("Hello", 123);
            testObj.Add("World", 999);
            Assert.AreEqual(testObj.ToString(), "{\"Hello\":123,\"World\":999}");
        }

        [TestMethod]
        public void TestNewJObjectToStringTwoItemNumIndent()
        {
            JObject testObj = new JObject();
            testObj.Add("Hello", 123);
            testObj.Add("World", 999);
            Assert.AreEqual(testObj.ToString(JsonFormat.Indent), "{\r\n  \"Hello\": 123,\r\n  \"World\": 999\r\n}");
        }
    }
}
