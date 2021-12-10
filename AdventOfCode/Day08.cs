using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day08
    {
        private readonly string[] _input;

        public Day08(string[] input = null)
        {
            _input = input ?? Input.ReadAllLines(GetType().Name);
        }

        public int Part1()
        {
            var outputValues = _input.Select(i =>
                i.Split("|", StringSplitOptions.RemoveEmptyEntries| StringSplitOptions.TrimEntries)[1]);
            var count = 0;
            foreach (var o in outputValues)
            {
                var segments = o.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                count += segments.Count(s => s.Length == 2 || s.Length == 3 || s.Length == 4 || s.Length == 7);
            }
            return count;
        }

        public int Part2()
        {
            return _input.Sum(CalculateOutputValue);
        }

        public int CalculateOutputValue(string input)
        {
            var splitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

            var parts = input.Split("|", splitOptions);
            var signalPatterns = parts[0].Split(" ", splitOptions);
            var outputValues = parts[1].Split(" ", splitOptions);

            signalPatterns = SortStrings(signalPatterns);
            outputValues = SortStrings(outputValues);

            var digits = new string[10];

            digits[1] = signalPatterns.First(p => p.Length == 2);
            digits[7] = signalPatterns.First(p => p.Length == 3);
            digits[4] = signalPatterns.First(p => p.Length == 4);
            digits[8] = signalPatterns.First(p => p.Length == 7);
            digits[9] = signalPatterns.First(p => p.Length == 6 && digits[4].All(p.Contains));
            digits[3] = signalPatterns.First(p => p.Length == 5 && digits[1].All(p.Contains));
            digits[6] = signalPatterns.First(p => p.Length == 6 && !digits[1].All(p.Contains));
            digits[0] = signalPatterns.First(p => p.Length == 6 && p != digits[9] && p != digits[6]);
            
            digits[5] = string.Concat(digits[6].Where(c => digits[9].Contains(c)));
            digits[2] = signalPatterns.First(p => !digits.Contains(p));

            var key = new Dictionary<string, int>();
            for (var i = 0; i < digits.Length; i++)
            {
                key.Add(digits[i], i);
            }

            return int.Parse(string.Concat(outputValues.Select(o => key[o].ToString())));
        }

        private static string[] SortStrings(string[] input)
        {
            return input.Select(i => string.Concat(i.OrderBy(c => c))).ToArray();
        }

    }
}
