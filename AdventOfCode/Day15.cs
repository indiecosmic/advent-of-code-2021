using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode
{
    public class Day15
    {
        private readonly int[,] map;
        private readonly int[,] costs;
        private readonly (int x, int y)[] directions = new[]
        {
            (x: 0, y: 1),
            (x: 1, y: 0),
            (x: 0, y: -1),
            (x: -1, y: 0)
        };
        private readonly (int x, int y) destination;
        private readonly int height;
        private readonly int width;
        

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
                    if (IsValid(target.x, target.y, cost)) {
                        visitingQueue.Enqueue((target.x, target.y));
                        costs[target.x, target.y] = cost + map[target.x, target.y];
                    }
                }
            }

            return costs[destination.x, destination.y];
        }

        public int Part2()
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

        private static int[,] CreateBigMap(int[,] map)
        {
            var height = map.GetLength(0) * 5;
            var width = map.GetLength(1) * 5;
            var copy = new int[map.GetLength(1), map.GetLength(0)];



            return null;
        }

        private bool IsValid(int x, int y, int cost)
        {
            if (x >= 0 && y >= 0 && x < width && y < height && cost+map[x,y] < costs[x, y])
                return true;
            return false;
        }

    }
}
