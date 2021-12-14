using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day14
    {
        private readonly string template;
        private readonly IDictionary<string, string> rules = new Dictionary<string,string>();
        private readonly IDictionary<string, string[]> replacements = new Dictionary<string, string[]>();

        public Day14(string[] input = null)
        {
            input ??= Input.ReadAllLines();
            template = input[0];

            var inputRules = input.Skip(2);
            foreach (var rule in inputRules)
            {
                var parts = rule.Split(" -> ");
                rules.Add(parts[0], parts[1]);
            }

            foreach (var rule in rules)
            {
                replacements.Add(rule.Key, new[]
                {
                    rule.Key.Substring(0,1) + rule.Value,
                    rule.Value + rule.Key.Substring(1,1)
                });
            }
        }

        public int Part1()
        {
            var result = Process(template, 10);
            var counts = result.Distinct().ToDictionary(
                key => key,
                key => result.Count(r => r == key)
                );

            return counts.Values.Max() - counts.Values.Min();
        }

        public long Part2()
        {
            IDictionary<string, long> counts = new Dictionary<string, long>();
            for (var i = 0; i < template.Length - 1; i++)
            {
                var key = template.Substring(i, 2);
                if (!counts.ContainsKey(key))
                    counts.Add(key, 0);
                counts[key]++;
            }

            for (var i = 0; i < 40; i++)
            {
                counts = Process2(counts);
            }

            var letters = new Dictionary<string, long>();
            foreach (var c in counts)
            {
                if (c.Value == 0)
                    continue;
                var first = c.Key.Substring(0, 1);
                if (!letters.ContainsKey(first))
                    letters.Add(first, 0);
                letters[first] += c.Value;
            }
            letters[template.Last().ToString()]++;

            return letters.Values.Max() - letters.Values.Min();
        }

        public IDictionary<string, long> Process2(IDictionary<string, long> counts)
        {
            var newCounts = new Dictionary<string, long>();
            foreach (var count in counts)
            {
                if (count.Value == 0)
                    continue;
                foreach (var r in replacements[count.Key])
                {
                    if (!newCounts.ContainsKey(r))
                        newCounts.Add(r, 0);
                    newCounts[r] += count.Value;
                }
            }
            return newCounts;
        }

        public string Process(string template, int iterations)
        {
            for (var i = 0; i < iterations; i++)
            {
                template = Process(template);
            }
            return template;
        }

        public string Process(string source)
        {
            var polymer = new StringBuilder();

            for (var i = 0; i <= source.Length - 1; i++)
            {
                if (i == source.Length - 1)
                {
                    polymer.Append(source[^1]);
                    break;
                }

                var key = source.Substring(i, 2);
                var value = rules[key];
                polymer.Append(key[0]).Append(value);
            }

            return polymer.ToString();
        }

    }
}
