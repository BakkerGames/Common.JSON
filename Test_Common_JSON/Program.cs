using Common.JSON;
using System;

namespace Test_Common_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject jo = JObject.Parse("{\r\n  \"key\": 123,\r\n  \"otherkey\": 789.12\r\n}");
            Console.WriteLine(jo.ToString());
            Console.Read();
        }
    }
}
