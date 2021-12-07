using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day06
    {
        private readonly string _input;

        public Day06(string input = null)
        {
            _input = input ?? Input.ReadAllLines(GetType().Name).First();
        }

        public int Part1()
        {
            var fish = _input.Split(",").Select(int.Parse).ToList();

            for (var i = 0; i < 80; i++)
            {
                var toAdd = 0;
                for (var j = 0; j < fish.Count; j++)
                {
                    if (fish[j] == 0)
                    {
                        fish[j] = 6;
                        toAdd++;
                    }
                    else
                        fish[j]--;
                }
                for (var x = 0; x < toAdd; x++)
                    fish.Add(8);
            }

            return fish.Count;
        }

        public long Part2()
        {
            var fishes = _input.Split(",").Select(int.Parse).ToList();
            var counts = new Dictionary<int, long>();
            for (var i = 0; i <= 8; i++)
                counts[i] = 0;
            foreach (var fish in fishes)
                counts[fish]++;

            for (int i = 0; i < 256; i++)
            {
                long last = counts[0];
                for (int j = 0; j < 8; j++) counts[j] = counts[j + 1];
                counts[6] += last;
                counts[8] = last;
            }

            return counts.Values.Sum();
        }
    }
}
