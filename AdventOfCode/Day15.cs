using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day15
    {
        private int[,] map;
        private readonly (int x, int y) north = (x: 0, y: -1);
        private readonly (int x, int y) south = (x: 0, y: 1);
        private readonly (int x, int y) west = (x: -1, y: 0);
        private readonly (int x, int y) east = (x: 1, y: 0);

        public Day15(string[] input = null)
        {
            input ??= Input.ReadAllLines();
            var height = input.Length;
            var width = input[0].Length;

            map = new int[height, width];

            for (var row = 0; row < height; row++)
            {
                for (var col = 0; col < width; col++)
                {
                    map[col, row] = (int)char.GetNumericValue(input[row][col]);
                }
            }
        }

        public int Part1()
        {
            return 0;
        }

    }
}
