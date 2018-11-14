using Common.JSON;
using System;

namespace Test.Common.JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing {\"Hello\",123}");
            JObject testObj = new JObject();
            testObj.Add("Hello", 123);
            Console.WriteLine("{\n  \"Hello\": 123\n}");
            Console.WriteLine(testObj.ToString(JsonFormat.Indent));
            Console.ReadLine();
        }
    }
}
