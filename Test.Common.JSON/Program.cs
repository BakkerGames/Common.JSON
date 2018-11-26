using Common.JSON;
using System;
using System.IO;

namespace Test.Common.JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            //JObject testObj = new JObject();
            //testObj.Add("Hello", -123.45e23);
            //Console.WriteLine("{\n  \"Hello\": -123.45e23\n}");
            //Console.WriteLine(testObj.ToString(JsonFormat.Indent));
            //Console.ReadLine();

            string testFilename = "D:\\Projects\\Common.JSON\\TestData\\save3.hg";
            string outTestFilename = "D:\\Projects\\Common.JSON\\TestData\\save3out_indent.json";
            using (StreamReader sr = new StreamReader(testFilename))
            {
                JObject jTest = JObject.Parse(sr);
                File.WriteAllText(outTestFilename, jTest.ToString(JsonFormat.Indent));
            }
            Console.WriteLine();
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }
    }
}
