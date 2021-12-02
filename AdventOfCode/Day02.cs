using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day02
    {
        public static long Part1(string[] input = null)
        {
            input ??= Input.ReadAllLines(nameof(Day02));

            var movements = input.Select(ParseInput);
            var (position, depth) = (0, 0);
            foreach (var movement in movements)
            {
                position += movement.position;
                depth += movement.depth;
            }

            return position * depth;
        }

        private static (int position, int depth) ParseInput(string arg)
        {
            var parts = arg.Split(" ");
            var direction = parts[0];
            var value = int.Parse(parts[1]);
            switch (direction)
            {
                case "forward":
                    return (value, 0);
                case "up":
                    return (0, -value);
                case "down":
                    return (0, value);
            }

            return (0, 0);
        }

        public static long Part2(string[] input = null)
        {
            input ??= Input.ReadAllLines(nameof(Day02));

            var movements = input.Select(ParseInput);
            var (position, depth, aim) = (0, 0, 0);
            foreach (var movement in movements)
            {
                aim += movement.depth;
                position += movement.position;
                depth += (aim * movement.position);
            }

            return position * depth;
        }
        
    }
}
