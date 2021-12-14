using System.Diagnostics;
using System.IO;

namespace AdventOfCode
{
    public static class Input
    {
        public static string[] ReadAllLines()
        {
            var methodInfo = new StackTrace().GetFrame(1).GetMethod();
            var className = methodInfo.ReflectedType.Name;
            return ReadAllLines(className);
        }

        public static string[] ReadAllLines(string day)
        {
            var filename = $"{day.ToLower()}_input.txt";
            return File.ReadAllLines(filename);
        }
       
    }
}
