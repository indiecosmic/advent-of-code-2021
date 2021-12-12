using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day09
    {
        private readonly int[,] _heightMap;
        private readonly int rows;
        private readonly int cols;


        public Day09(string[] input = null)
        {
            input ??= Input.ReadAllLines(GetType().Name);

            rows = input.Length;
            cols = input[0].Length;

            _heightMap = new int[rows, cols];
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    _heightMap[row, col] = (int)char.GetNumericValue(input[row][col]);
                }
            }
        }

        public int Part1()
        {
            var lowPoints = FindLowPoints();
            return lowPoints.Sum(p => p.height + 1);
        }

        public int Part2()
        {
            var lowPoints = FindLowPoints();

            var basins = lowPoints.Select(Basin);

            var largest = basins.OrderByDescending(b => b.Count()).Take(3);
            return largest.Aggregate(1, (current, l) => current * l.Count());
        }

        private IEnumerable<(int row, int col, int height)> FindLowPoints()
        {
            var lowPoints = new List<(int row, int col, int height)>();
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    var height = _heightMap[row, col];
                    var adjacent = AdjacentValues(row, col);
                    if (adjacent.All(a => a.height > height))
                    {
                        lowPoints.Add((row, col, height));
                    }
                }
            }
            return lowPoints;
        }

        private IEnumerable<(int row, int col, int height)> AdjacentValues(int row, int col)
        {
            var adj = new List<(int,int,int)>();
            if (row > 0)
                adj.Add((row-1, col, _heightMap[row - 1, col]));
            if (row < rows - 1)
                adj.Add((row+1, col, _heightMap[row + 1, col]));
            if (col > 0)
                adj.Add((row, col-1, _heightMap[row, col - 1]));
            if (col < cols - 1)
                adj.Add((row, col+1, _heightMap[row, col + 1]));
            return adj;
        }

        private IEnumerable<(int row, int col, int height)> Basin((int row, int col, int height) tile)
        {
            var basin = new List<(int, int, int)>();
            Basin(tile, basin);

            return basin;
        }

        private void Basin((int row, int col, int height) tile, IList<(int, int, int)> basin)
        {
            if (basin.Contains(tile))
                return;
            if (tile.height == 9)
                return;
            basin.Add(tile);
            var adj = AdjacentValues(tile.row, tile.col);
            foreach (var a in adj)
                Basin(a, basin);
        }

    }
}
