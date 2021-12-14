using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day13
    {
        private readonly string[] _input;
        private HashSet<(int x, int y)> _dots;
        private readonly List<(char dir, int pos)> _folds;

        public Day13(string[] input = null)
        {
            _input = input ?? Input.ReadAllLines();

            _dots = new HashSet<(int x, int y)>();
            _folds = new List<(char, int)>();
            var foldInstructions = false;
            foreach (var row in _input)
            {
                if (string.IsNullOrWhiteSpace(row))
                {
                    foldInstructions = true;
                    continue;
                }

                if (!foldInstructions)
                {
                    var parts = row.Split(",");
                    _dots.Add((int.Parse(parts[0]), int.Parse(parts[1])));
                }
                else
                {
                    var parts = row.Split("=");
                    _folds.Add(parts[0].EndsWith("x") ? ('x', int.Parse(parts[1])) : ('y', int.Parse(parts[1])));
                }
            }
        }

        public int Part1()
        {
            var firstFold = _folds.First();
            Fold(firstFold);

            return _dots.Count;
        }

        public void Part2()
        {
            foreach (var fold in _folds)
                Fold(fold);
            Print();
        }

        private void Print()
        {
            var width = _dots.Select(c => c.x).Max() + 1;
            var height = _dots.Select(c => c.y).Max() + 1;

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var s = _dots.Contains((x, y)) ? "#" : ".";
                    Console.Write(s);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void Fold((char dir, int pos) fold)
        {
            var (dir, pos) = fold;
            if (dir == 'y')
                FoldUp(pos);
            else
                FoldLeft(pos);
        }

        private void FoldUp(int line)
        {
            var newDots = new HashSet<(int x, int y)>();
            foreach (var dot in _dots)
            {
                if (dot.y < line)
                    newDots.Add(dot);
                else
                {
                    var newDot = (dot.x, line-(dot.y-line));
                    if (!newDots.Contains(newDot))
                        newDots.Add(newDot);
                }
            }

            _dots = newDots;
        }

        private void FoldLeft(int line)
        {
            var newDots = new HashSet<(int x, int y)>();
            foreach (var dot in _dots)
            {
                if (dot.x < line)
                    newDots.Add(dot);
                else
                {
                    var newDot = (line-(dot.x-line), dot.y);
                    if (!newDots.Contains(newDot))
                        newDots.Add(newDot);
                }
            }

            _dots = newDots;
        }
    }
}
