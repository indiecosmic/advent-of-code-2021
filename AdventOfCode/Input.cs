using System.IO;

namespace AdventOfCode
{
    public static class Input
    {
        public static string[] ReadAllLines(string day)
        {
            var filename = $"{day.ToLower()}_input.txt";
            return File.ReadAllLines(filename);
        }
       
    }
}
