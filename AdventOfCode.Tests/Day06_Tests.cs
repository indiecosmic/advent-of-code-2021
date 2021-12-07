using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day06_Tests
    {
        private readonly string _input = "3,4,3,1,2";

        private Day06 Subject => new Day06(_input);

        [Fact]
        public void Part1()
        {
            var result = Subject.Part1();
            Assert.Equal(5934, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Subject.Part2();
            Assert.Equal(26984457539, result);
        }
    }
}
