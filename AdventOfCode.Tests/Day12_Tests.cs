using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day12_Tests : TestBase<Day12, string[]>
    {
        public Day12_Tests()
        :base(new []
        {
            "start-A",
            "start-b",
            "A-c",
            "A-b",
            "b-d",
            "A-end",
            "b-end"
        })
        {
        }

        [Fact]
        public void Part1()
        {
            var result = Subject.Part1();
            Assert.Equal(10, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Subject.Part2();
            Assert.Equal(36, result);
        }
    }
}
