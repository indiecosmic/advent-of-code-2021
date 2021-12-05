using System;
using System.Linq;

namespace AdventOfCode
{
    public readonly struct Line
    {
        public Point Start { get; }
        public Point End { get; }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public bool IsParallel => Start.X != End.X && Start.Y != End.Y;

        public static Line Parse(string row)
        {
            var points = row.Split("->", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(Point.Parse)
                .ToArray();
            
            return new Line(points[0], points[1]);
        }
    }
}
