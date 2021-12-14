using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day14_Tests : TestBase<Day14, string[]>
    {
        public Day14_Tests() : base(new[]
        {
            "NNCB",
            "",
            "CH -> B",
            "HH -> N",
            "CB -> H",
            "NH -> C",
            "HB -> C",
            "HC -> B",
            "HN -> C",
            "NN -> C",
            "BH -> H",
            "NC -> B",
            "NB -> B",
            "BN -> B",
            "BB -> N",
            "BC -> B",
            "CC -> N",
            "CN -> C"})
        {
        }

        [Fact]
        public void Part1()
        {
            var result = Subject.Part1();
            Assert.Equal(1588, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Subject.Part2();
            Assert.Equal(2188189693529, result);
        }

        [Fact]
        public void Process()
        {
            var result = Subject.Process("NNCB", 4);
            Assert.Equal("NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB", result);
        }
    }
}
