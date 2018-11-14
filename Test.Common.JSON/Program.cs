using Common.JSON;
using System;

namespace Test.Common.JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject testObj = new JObject();
            testObj.Add("Hello", -123.45e23);
            Console.WriteLine("{\n  \"Hello\": -123.45e23\n}");
            Console.WriteLine(testObj.ToString(JsonFormat.Indent));
            Console.ReadLine();
        }
    }
}
