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
            var lines = _input.Select(Line.Parse)
                .Where(l => !l.IsParallel);

            var pointsCovered = PlotLines(lines);

            return pointsCovered.Values.Count(v => v > 1);
        }

        public int Part2()
        {
            var lines = _input.Select(Line.Parse);

            var pointsCovered = PlotLines(lines);
            
            return pointsCovered.Values.Count(v => v > 1);
        }

        private Dictionary<(int x, int y), int> PlotLines(IEnumerable<Line> lines)
        {
            var pointsCovered = new Dictionary<(int x, int y), int>();
            foreach (var line in lines)
            {
                var (x, y) = line.Start;
                var (dx, dy) = line.End - line.Start;
                var (endX, endY) = line.End;

                var stepX = dx > 0 ? 1 : dx < 0 ? -1 : 0;
                var stepY = dy > 0 ? 1 : dy < 0 ? -1 : 0;

                if (!pointsCovered.ContainsKey((x, y)))
                    pointsCovered.Add((x, y), 0);
                pointsCovered[(x, y)]++;

                while ((x, y) != (endX, endY))
                {
                    x += stepX;
                    y += stepY;

                    if (!pointsCovered.ContainsKey((x, y)))
                        pointsCovered.Add((x, y), 0);
                    pointsCovered[(x, y)]++;
                }
            }

            return pointsCovered;
        }
    }
}
