using Common.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Common.JSON
{
    [TestClass]
    public class UnitTestToString
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
        public void TestNewJArrayToStringOneItemNull()
        {
            JArray testObj = new JArray();
            testObj.Add(null);
            Assert.AreEqual(testObj.ToString(JsonFormat.None), "[null]");
        }

        [TestMethod]
        public void TestNewJArrayToStringOneItemFalse()
        {
            JArray testObj = new JArray();
            testObj.Add(false);
            Assert.AreEqual(testObj.ToString(JsonFormat.None), "[false]");
        }

        [TestMethod]
        public void TestNewJArrayToStringOneItemTrue()
        {
            JArray testObj = new JArray();
            testObj.Add(true);
            Assert.AreEqual(testObj.ToString(JsonFormat.None), "[true]");
        }

        [TestMethod]
        public void TestNewJArrayToStringOneItemNumNeg()
        {
            JArray testObj = new JArray();
            testObj.Add(-123);
            Assert.AreEqual(testObj.ToString(JsonFormat.None), "[-123]");
        }

        [TestMethod]
        public void TestNewJArrayToStringOneItemNumZero()
        {
            JArray testObj = new JArray();
            testObj.Add(0);
            Assert.AreEqual(testObj.ToString(JsonFormat.None), "[0]");
        }

        [TestMethod]
        public void TestNewJArrayToStringOneItemNumDec()
        {
            JArray testObj = new JArray();
            testObj.Add(-123.45);
            Assert.AreEqual(testObj.ToString(JsonFormat.None), "[-123.45]");
        }

        [TestMethod]
        public void TestNewJArrayToStringOneItemNumFloat()
        {
            JArray testObj = new JArray();
            testObj.Add(-123.45e23);
            Assert.AreEqual(testObj.ToString(JsonFormat.None), "[-1.2345E+25]");
        }

        [TestMethod]
        public void TestNewJArrayToStringOneItemNumFloatZero()
        {
            JArray testObj = new JArray();
            testObj.Add(0e23);
            Assert.AreEqual(testObj.ToString(JsonFormat.None), "[0]");
        }

        [TestMethod]
        public void TestNewJArrayToStringOneItemNumDecZero()
        {
            JArray testObj = new JArray();
            testObj.Add(0.0);
            Assert.AreEqual(testObj.ToString(JsonFormat.None), "[0]");
        }

        [TestMethod]
        public void TestNewJArrayToStringOneItemNumDecZeroExtra()
        {
            JArray testObj = new JArray();
            testObj.Add(-000123.45000);
            Assert.AreEqual(testObj.ToString(JsonFormat.None), "[-123.45]");
        }

        [TestMethod]
        public void TestNewJArrayToStringTwoItemNum()
        {
            JArray testObj = new JArray();
            testObj.Add(123);
            testObj.Add(999);
            Assert.AreEqual(testObj.ToString(JsonFormat.None), "[123,999]");
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
        public void TestNewJObjectToStringTabs()
        {
            JObject testObj = new JObject();
            Assert.AreEqual(testObj.ToString(JsonFormat.Tabs), "{}");
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
        public void TestNewJObjectToStringOneItemNumTabs()
        {
            JObject testObj = new JObject();
            testObj.Add("Hello", 123);
            Assert.AreEqual(testObj.ToString(JsonFormat.Tabs), "{\r\n\t\"Hello\": 123\r\n}");
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

        [TestMethod]
        public void TestNewJObjectToStringTwoItemNumTabs()
        {
            JObject testObj = new JObject();
            testObj.Add("Hello", 123);
            testObj.Add("World", 999);
            Assert.AreEqual(testObj.ToString(JsonFormat.Tabs), "{\r\n\t\"Hello\": 123,\r\n\t\"World\": 999\r\n}");
        }
    }
}
