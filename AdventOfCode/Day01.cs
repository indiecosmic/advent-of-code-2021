using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day01
    {
        public static int Part1(string[] input = null)
        {
            input ??= Input.ReadAllLines(nameof(Day01));

            var numbers = input.Select(int.Parse).ToList();
            var increases = 0;
            for (var i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] > numbers[i - 1]) increases++;
            }

            return increases;
        }

        public static int Part2(string[] input = null)
        {
            input ??= Input.ReadAllLines(nameof(Day01));

            var numbers = input.Select(int.Parse).ToList();

            var threeMeasurementWindows = new List<int>();
            for (var i = 0; i < numbers.Count - 2; i++)
            {
                threeMeasurementWindows.Add(numbers[i] + numbers[i+1] + numbers[i+2]);
            }
            
            var increases = 0;
            for (var i = 1; i < threeMeasurementWindows.Count; i++)
            {
                if (threeMeasurementWindows[i] > threeMeasurementWindows[i - 1]) increases++;
            }

            return increases;
        }
    }
}
