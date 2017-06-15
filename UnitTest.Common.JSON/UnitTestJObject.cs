using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.JSON;

namespace UnitTest.Common.JSON
{
    [TestClass]
    public class UnitTestJObject
    {
        [TestMethod]
        public void TestNullJObjectWithWhitespace()
        {
            // arrange
            string actualValue;
            string expectedValue = "{}";
            JObject jo = new JObject();
            // act
            actualValue = jo.ToString(JsonFormat.Indent);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestNullJObjectNoWhitespace()
        {
            // arrange
            string actualValue;
            string expectedValue = "{}";
            JObject jo = new JObject();
            // act
            actualValue = jo.ToString(JsonFormat.None);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestNullJObjectDefaultWhitespace()
        {
            // arrange
            string actualValue;
            string expectedValue = "{}";
            JObject jo = new JObject();
            // act
            actualValue = jo.ToString();
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectNullValue()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\"key\":null}";
            JObject jo = new JObject
            {
                { "key", null }
            };
            // act
            actualValue = jo.ToString(JsonFormat.None);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectFalseValue()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\"key\":false}";
            JObject jo = new JObject
            {
                { "key", false }
            };
            // act
            actualValue = jo.ToString(JsonFormat.None);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectTrueValue()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\"key\":true}";
            JObject jo = new JObject
            {
                { "key", true }
            };
            // act
            actualValue = jo.ToString(JsonFormat.None);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectStringValue()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\"key\":\"abc\"}";
            JObject jo = new JObject
            {
                { "key", "abc" }
            };
            // act
            actualValue = jo.ToString(JsonFormat.None);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectStringValueCtrlChars()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\"key\":\"\\r\\n\\t\\b\\f\\u1234\"}";
            JObject jo = new JObject
            {
                { "key", "\r\n\t\b\f\u1234" }
            };
            // act
            actualValue = jo.ToString(JsonFormat.None);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectIntValue()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\"key\":123}";
            JObject jo = new JObject
            {
                { "key", 123 }
            };
            // act
            actualValue = jo.ToString(JsonFormat.None);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectIntValueWhitespace()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\r\n  \"key\": 123\r\n}";
            JObject jo = new JObject
            {
                { "key", 123 }
            };
            // act
            actualValue = jo.ToString(JsonFormat.Indent);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectDoubleValue()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\"key\":123.45}";
            JObject jo = new JObject
            {
                { "key", 123.45 }
            };
            // act
            actualValue = jo.ToString(JsonFormat.None);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectDateValue()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\"key\":\"2017-01-02T00:00:00.0000000\"}";
            JObject jo = new JObject
            {
                { "key", DateTime.Parse("01/02/2017") }
            };
            // act
            actualValue = jo.ToString(JsonFormat.None);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectDatetimeValue()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\"key\":\"2017-01-02T16:42:25.0000000\"}";
            JObject jo = new JObject
            {
                { "key", DateTime.Parse("01/02/2017 16:42:25") }
            };
            // act
            actualValue = jo.ToString(JsonFormat.None);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectJObjectValue()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\"key\":{\"newkey\":456}}";
            JObject jo2 = new JObject
            {
                { "newkey", 456 }
            };
            JObject jo = new JObject
            {
                { "key", jo2 }
            };
            // act
            actualValue = jo.ToString(JsonFormat.None);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectJArrayValue()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\"key\":[\"newkey\",456]}";
            JArray ja = new JArray
            {
                "newkey",
                456
            };
            JObject jo = new JObject
            {
                { "key", ja }
            };
            // act
            actualValue = jo.ToString(JsonFormat.None);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectMultiValue()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\"key\":123,\"otherkey\":789.12}";
            JObject jo = new JObject
            {
                { "key", 123 },
                { "otherkey", 789.12 }
            };
            // act
            actualValue = jo.ToString(JsonFormat.None);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectMultiValueWhitespace()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\r\n  \"key\": 123,\r\n  \"otherkey\": 789.12\r\n}";
            JObject jo = new JObject
            {
                { "key", 123 },
                { "otherkey", 789.12 }
            };
            // act
            actualValue = jo.ToString(JsonFormat.Indent);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectNewEmpty()
        {
            // arrange
            string actualValue;
            string expectedValue = "{}";
            JObject jo = JObject.Parse(expectedValue);
            // act
            actualValue = jo.ToString(JsonFormat.Indent);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestJObjectNewValues()
        {
            // arrange
            string actualValue;
            string expectedValue = "{\r\n  \"key\": 123,\r\n  \"otherkey\": 789.12\r\n}";
            JObject jo = JObject.Parse(expectedValue);
            // act
            actualValue = jo.ToString(JsonFormat.Indent);
            // assert
            Assert.AreEqual(expectedValue, actualValue);
        }

    }
}
