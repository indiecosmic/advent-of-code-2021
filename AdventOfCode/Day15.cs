using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode
{
    public class Day15
    {
        private int[,] map;
        private int[,] costs;
        private readonly (int x, int y)[] directions = new[]
        {
            (x: 0, y: 1),
            (x: 1, y: 0),
            (x: 0, y: -1),
            (x: -1, y: 0)
        };
        private (int x, int y) destination;
        private int height;
        private int width;


        public Day15(string[] input = null)
        {
            input ??= Input.ReadAllLines();
            height = input.Length;
            width = input[0].Length;
            map = new int[width, height];
            costs = new int[width, height];
            for (var row = 0; row < height; row++)
            {
                for (var col = 0; col < width; col++)
                {
                    map[col, row] = (int)char.GetNumericValue(input[row][col]);
                    costs[col, row] = int.MaxValue;
                }
            }

            destination = (width - 1, height - 1);
        }

        public int Part1()
        {
            var visitingQueue = new Queue<(int x, int y)>();
            var source = (x: 0, y: 0);
            costs[0, 0] = 0;
            visitingQueue.Enqueue(source);

            while (visitingQueue.Count > 0)
            {
                var next = visitingQueue.Dequeue();
                foreach (var dir in directions)
                {
                    var target = (x: next.x + dir.x, y: next.y + dir.y);
                    var cost = costs[next.x, next.y];
                    if (IsValid(target.x, target.y, cost))
                    {
                        visitingQueue.Enqueue((target.x, target.y));
                        costs[target.x, target.y] = cost + map[target.x, target.y];
                    }
                }
            }

            return costs[destination.x, destination.y];
        }

        public int Part2()
        {
            map = CreateBigMap(map, 5);
            height = map.GetLength(0);
            width = map.GetLength(1);
            costs = new int[width,height];
            for (var row = 0; row < height; row++)
            {
                for (var col = 0; col < width; col++)
                {
                    costs[col, row] = int.MaxValue;
                }
            }
            destination = (width - 1, height - 1);

            var visitingQueue = new Queue<(int x, int y)>();
            var source = (x: 0, y: 0);
            costs[0, 0] = 0;
            visitingQueue.Enqueue(source);

            while (visitingQueue.Count > 0)
            {
                var next = visitingQueue.Dequeue();
                foreach (var dir in directions)
                {
                    var target = (x: next.x + dir.x, y: next.y + dir.y);
                    var cost = costs[next.x, next.y];
                    if (IsValid(target.x, target.y, cost))
                    {
                        visitingQueue.Enqueue((target.x, target.y));
                        costs[target.x, target.y] = cost + map[target.x, target.y];
                    }
                }
            }

            return costs[destination.x, destination.y];
        }

        public static int[,] CreateBigMap(int[,] map, int multiplier)
        {
            var origHeight = map.GetLength(0);
            var origWidth = map.GetLength(1);

            var height = map.GetLength(0) * multiplier;
            var width = map.GetLength(1) * multiplier;
            var copy = new int[width, height];

            for (var rowM = 0; rowM < multiplier; rowM++)
            {
                for (var colM = 0; colM < multiplier; colM++)
                {
                    for (var row = 0; row < origHeight; row++)
                    {
                        for (var col = 0; col < origWidth; col++)
                        {
                            var val = map[col, row] + rowM + colM;
                            if (val > 9)
                                val = val - 9;

                            copy[col + colM * origWidth, row + rowM * origHeight] = val;
                        }
                    }
                }
            }

            return copy;
        }

        private bool IsValid(int x, int y, int cost)
        {
            if (x >= 0 && y >= 0 && x < width && y < height && cost + map[x, y] < costs[x, y])
                return true;
            return false;
        }

    }
}
