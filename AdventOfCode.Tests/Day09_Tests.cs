using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day09_Tests : TestBase<Day09, string[]>
    {
        public Day09_Tests()
        : base(new[]{ 
                "2199943210",
                "3987894921",
                "9856789892",
                "8767896789",
                "9899965678"
        })
        {
        }

        [Fact]
        public void Part1()
        {
            var result = Subject.Part1();
            Assert.Equal(15, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Subject.Part2();
            Assert.Equal(1134, result);
        }
    }
}
