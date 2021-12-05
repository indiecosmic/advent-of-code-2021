using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day05
    {
        private readonly string[] _input;

        public Day05(string[] input = null)
        {
            _input = input ?? Input.ReadAllLines(GetType().Name);
        }

        public int Part1()
        {
            var lines = _input.Select(ParseLine);
            var hvLines = lines.Where(l => !l.IsParallel).ToArray();

            var pointsCovered = new Dictionary<(int x, int y), int>();
            foreach (var line in hvLines)
            {
                var xMin = Math.Min(line.Start.X, line.End.X);
                var yMin = Math.Min(line.Start.Y, line.End.Y);
                var xMax = Math.Max(line.Start.X, line.End.X);
                var yMax = Math.Max(line.Start.Y, line.End.Y);
                var dx = xMax - xMin;
                var dy = yMax - yMin;

                var x = xMin;
                var y = yMin;

                if (!pointsCovered.ContainsKey((x, y)))
                    pointsCovered.Add((x, y), 0);
                pointsCovered[(x, y)]++;

                while (x < xMax || y < yMax)
                {
                    if (dx > 0)
                    {
                        x++;
                    }

                    if (dy > 0)
                    {
                        y++;
                    }

                    if (!pointsCovered.ContainsKey((x, y)))
                        pointsCovered.Add((x, y), 0);
                    pointsCovered[(x, y)]++;
                }
            }
            
            return pointsCovered.Values.Count(v => v > 1);
        }

        public int Part2()
        {
            var lines = _input.Select(ParseLine);

            var pointsCovered = new Dictionary<(int x, int y), int>();
            foreach (var line in lines)
            {
                var (x, y) = line.Start;
                var (dx, dy) = line.End - line.Start;

                var stepX = dx > 0 ? 1 : dx < 0 ? -1 : 0;
                var stepY = dy > 0 ? 1 : dy < 0 ? -1 : 0;

                if (!pointsCovered.ContainsKey((x, y)))
                    pointsCovered.Add((x, y), 0);
                pointsCovered[(x, y)]++;

                while ((x, y) != (line.End.X, line.End.Y))
                {
                    x += stepX;
                    y += stepY;
                    
                    if (!pointsCovered.ContainsKey((x, y)))
                        pointsCovered.Add((x, y), 0);
                    pointsCovered[(x, y)]++;
                }
            }
            
            return pointsCovered.Values.Count(v => v > 1);
        }

        public Line ParseLine(string row)
        {
            var points = row.Split("->", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var start = points[0].Split(",").Select(int.Parse).ToArray();
            var end = points[1].Split(",").Select(int.Parse).ToArray();
            return new Line(new Point(start[0], start[1]), new Point(end[0], end[1]));
        }
    }
}
