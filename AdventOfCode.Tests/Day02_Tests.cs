using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day02_Tests
    {
        [Fact]
        public void Part1()
        {
            var input = new[]
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };
            var result = Day02.Part1(input);
            Assert.Equal(150, result);
        }

        [Fact]
        public void Part2()
        {
            var input = new[]
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };
            var result = Day02.Part2(input);
            Assert.Equal(900, result);
        }
    }
}
