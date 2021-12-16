using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class Util
    {
        public static int[,] To2DIntArray(string[] input)
        {
            var height = input.Length;
            var width = input[0].Length;
            var result = new int[width, height];
            for (var row = 0; row < height; row++)
            {
                for (var col = 0; col < width; col++)
                {
                    result[col, row] = (int)char.GetNumericValue(input[row][col]);
                }
            }
            return result;
        }

        public static string[] ToStringArray(int[,] input)
        {
            var height = input.GetLength(0);
            var width = input.GetLength(1);
            var s = new StringBuilder();
            for (var row = 0; row < height; row++)
            {
                
                for (var col = 0; col < width; col++)
                {
                    s.Append(input[col, row]);
                }
                s.AppendLine();
            }
            return s.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
