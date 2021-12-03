using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day03_Tests
    {
        [Fact]
        public void FindNumbers()
        {
            var input = new[]
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };
            var result = Day03.FindNumbers(input);
            var expected = ("10110", "01001");
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1()
        {
            var input = new[]
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };
            var result = Day03.Part1(input);
            Assert.Equal(198, result);
        }
    }
}
