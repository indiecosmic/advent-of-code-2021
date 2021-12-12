using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day10
    {
        private readonly string[] _input;
        private const string Openers = "([{<";

        private readonly string[] _pairs = new[]
        {
            "()",
            "[]",
            "{}",
            "<>"
        };

        public Day10(string[] input = null)
        {
            _input = input ?? Input.ReadAllLines(GetType().Name);
        }

        public long Part1()
        {
            return _input.Sum(line => Score(line).score);
        }

        public long Part2()
        {
            var scores = new List<long>();
            foreach (var line in _input)
            {
                var (score, remainder) = Score(line);
                if (score == 0)
                {
                    while (remainder.TryPop(out var c))
                    {
                        var completionScore = CompletionScore(c);
                        score *= 5;
                        score += completionScore;
                    }
                    scores.Add(score);
                }
            }

            scores.Sort();

            return scores[scores.Count/2];
        }

        private (long score, Stack<char> remainder) Score(string line)
        {
            var chars = new Stack<char>();
            foreach (var c in line)
            {
                if (Openers.Contains(c))
                {
                    chars.Push(c);
                }
                else
                {
                    if (Matches(chars.Peek(), c))
                        chars.Pop();
                    else
                    {
                        switch (c)
                        {
                            case ')':
                                return (3, null);
                            case ']':
                                return (57, null);
                            case '}':
                                return (1197, null);
                            case '>':
                                return (25137, null);
                        }
                    }
                }
            }

            return (0, chars);
        }
        
        private bool Matches(char opener, char closer)
        {
            var str = new string(new[] { opener, closer });
            return _pairs.Contains(str);
        }

        private int CompletionScore(char c)
        {
            return c switch
            {
                '(' => 1,
                '[' => 2,
                '{' => 3,
                '<' => 4,
                _ => throw new Exception()
            };
        }
    }
}
