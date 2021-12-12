using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day11
    {
        private readonly string[] _input;
        public int[,] Map { get; }

        public string[] Output
        {
            get
            {
                var output = new List<string>();
                for (var row = 0; row < rows; row++)
                {
                    var s = "";
                    for (var col = 0; col < cols; col++)
                    {
                        s += Map[row, col].ToString();
                    }
                    output.Add(s);
                }

                return output.ToArray();
            }
        }

        private readonly int rows;
        private readonly int cols;

        public Day11(string[] input = null)
        {
            _input = input ?? Input.ReadAllLines(GetType().Name);
            rows = _input.Length;
            cols = _input[0].Length;

            Map = new int[rows, cols];
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    Map[row, col] = (int)char.GetNumericValue(_input[row][col]);
                }
            }
        }

        public int Part1()
        {
            var flashes = 0;
            for (var i = 0; i < 100; i++)
            {
                flashes += Tick();
            }

            return flashes;
        }

        public int Part2()
        {
            var step = 0;
            while (true)
            {
                var flashes = Tick();
                step++;
                if (flashes == 100)
                    return step;
            }
        }

        public int Tick()
        {
            var flashing = new List<(int row, int col)>();
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    Map[row, col]++;
                    if (Map[row, col] > 9)
                        flashing.Add((row, col));
                }
            }

            foreach (var flash in flashing)
                Flash(flash);

            var count = 0;
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    if (Map[row, col] == 0)
                        count++;
                }
            }

            return count;
        }

        private IEnumerable<(int row, int col, int height)> AdjacentValues(int row, int col)
        {
            var adj = new List<(int, int, int)>();
            if (row > 0)
                adj.Add((row - 1, col, Map[row - 1, col]));
            if (row < rows - 1)
                adj.Add((row + 1, col, Map[row + 1, col]));
            if (col > 0)
                adj.Add((row, col - 1, Map[row, col - 1]));
            if (col < cols - 1)
                adj.Add((row, col + 1, Map[row, col + 1]));
            return adj;
        }

        private void Flash((int row, int col) pos)
        {
            if (Map[pos.row, pos.col] == 0)
                return;

            Map[pos.row, pos.col] = 0;
            for (var row = pos.row - 1; row < pos.row + 2; row++)
            {
                if (row < 0 || row >= rows)
                    continue;

                for (var col = pos.col - 1; col < pos.col + 2; col++)
                {
                    if (col < 0 || col >= cols) continue;
                    if (col == pos.col && row == pos.row) continue;
                    if (Map[row, col] == 0) continue;
                    Map[row, col]++;

                    if (Map[row, col] > 9)
                        Flash((row, col));
                }
            }
        }
    }
}
