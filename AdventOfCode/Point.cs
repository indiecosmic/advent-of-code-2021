using System.Linq;

namespace AdventOfCode
{
    public readonly struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point operator -(Point a, Point b) => new(a.X - b.X, a.Y - b.Y);
        public static Point operator +(Point a, Point b) => new(a.X + b.X, a.Y + b.Y);

        public static Point Parse(string input)
        {
            var numbers = input.Split(",").Select(int.Parse).ToArray();
            return new Point(numbers[0], numbers[1]);
        }

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }
}