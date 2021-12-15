using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day15_Tests : TestBase<Day15, string[]>
    {
        public Day15_Tests()
            : base(new[]
            {
                "1163751742",
                "1381373672",
                "2136511328",
                "3694931569",
                "7463417111",
                "1319128137",
                "1359912421",
                "3125421639",
                "1293138521",
                "2311944581"
            })
        {
        }

        [Fact]
        public void Part1()
        {
            var result = Subject.Part1();
            Assert.Equal(40, result);
        }

    }
}
