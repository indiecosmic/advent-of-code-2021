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
    }
}
