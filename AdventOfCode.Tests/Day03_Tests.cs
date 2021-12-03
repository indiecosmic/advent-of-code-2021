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
        readonly string[] _input = new[]
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

    [Fact]
        public void FindNumbers()
        {
            var result = Day03.FindNumbers(_input);
            var expected = ("10110", "01001");
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1()
        {
            var result = Day03.Part1(_input);
            Assert.Equal(198, result);
        }

        [Fact]
        public void FindOxygenGeneratorRating()
        {
            var result = Day03.FindOxygenGeneratorRating(_input);
            Assert.Equal(23, result);
        }

        [Fact]
        public void FindCo2ScrubberRating()
        {
            var result = Day03.FindCo2ScrubberRating(_input);
            Assert.Equal(10, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day03.Part2(_input);
            Assert.Equal(230, result);
        }
    }
}
