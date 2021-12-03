using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day03
    {
        public static int Part1(string[] input = null)
        {
            input ??= Input.ReadAllLines(nameof(Day03));

            var (gamma, epsilon) = FindNumbers(input);



            return Convert.ToInt32(gamma,2) * Convert.ToInt32(epsilon, 2);
        }

        public static int Part2(string[] input = null)
        {
            input ??= Input.ReadAllLines(nameof(Day03));

            var oxygen = FindOxygenGeneratorRating(input);
            var co2 = FindCo2ScrubberRating(input);

            return oxygen * co2;
        }

        public static (string gamma, string epsilon) FindNumbers(string[] input)
        {
            var gamma = "";
            var epsilon = "";
            for (var i = 0; i < input[0].Length; i++)
            {
                var ones = 0;
                var zeros = 0;
                foreach (var item in input)
                {
                    if (item[i] == '1')
                        ones++;
                    else zeros++;
                }

                if (ones > zeros)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }

            return (gamma, epsilon);
        }

        public static int FindOxygenGeneratorRating(string[] input)
        {
            var length = input[0].Length;
            string rating = "";
            for (var i = 0; i < length; i++)
            {
                var mcb = MostCommonBit(input, i);
                input = Filter(input, mcb == 0 ? '0' : '1', i);
                if (input.Length == 1) {
                    rating = input[0];
                    break;
                }
            }

            return Convert.ToInt32(rating, 2);
        }

        public static int FindCo2ScrubberRating(string[] input)
        {
            var length = input[0].Length;
            string rating = "";
            for (var i = 0; i < length; i++)
            {
                var mcb = MostCommonBit(input, i);
                input = Filter(input, mcb == 0 ? '1' : '0', i);
                if (input.Length == 1)
                {
                    rating = input[0];
                    break;
                }
            }

            return Convert.ToInt32(rating, 2);
        }

        public static int MostCommonBit(string[] input, int index)
        {
            var ones = 0;
            var zeros = 0;
            foreach (var item in input)
            {
                if (item[index] == '1')
                    ones++;
                else zeros++;
            }

            if (ones > zeros)
                return 1;
            if (zeros > ones)
                return 0;
            return -1;
        }

        public static string[] Filter(string[] input, char bit, int index)
        {
            return input.Where(i => i[index] == bit).ToArray();
        }


    }
}
