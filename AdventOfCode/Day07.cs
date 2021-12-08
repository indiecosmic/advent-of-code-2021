using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day07
    {
        private readonly int[] _positions;

        public Day07(string input = null)
        {
            var input1 = input ?? Input.ReadAllLines(GetType().Name).First();
            _positions = input1.Split(",").Select(int.Parse).ToArray();
        }

        public int Part1()
        {
            var costs = new Dictionary<int, int>();
            var start = _positions.Min();
            var end = _positions.Max();

            for (var i = start; i <= end; i++)
            {
                costs[i] = _positions.Sum(x => Math.Abs(x - i));
            }

            return costs.Values.Min();
        }

        public int Part2()
        {
            var costs = new Dictionary<int, int>();
            var start = _positions.Min();
            var end = _positions.Max();

            for (var i = start; i <= end; i++)
            {
                costs[i] = _positions.Sum(x => FuelCost(Math.Abs(x - i)));
            }

            return costs.Values.Min();
        }

        public int FuelCost(int distance)
        {
            return distance * (distance + 1) / 2;
        }
    }
}
