using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day01_Tests
    {
        [Fact]
        public void Part1()
        {
            var input = new[]
            {
                "199",
                "200",
                "208",
                "210",
                "200",
                "207",
                "240",
                "269",
                "260",
                "263"
            };
            var result = Day01.Part1(input);
            Assert.Equal(7, result);
        }

        [Fact]
        public void Part2()
        {
            var input = new[]
            {
                "199",
                "200",
                "208",
                "210",
                "200",
                "207",
                "240",
                "269",
                "260",
                "263"
            };
            var result = Day01.Part2(input);
            Assert.Equal(5, result);
        }
    }
}
