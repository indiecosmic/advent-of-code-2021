using Xunit;

namespace AdventOfCode.Tests
{
    public class Day05_Tests
    {
        readonly string[] _input = {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2",
        };

        private Day05 Subject => new(_input);

        [Fact]
        public void Part1()
        {
            var result = Subject.Part1();
            Assert.Equal(5, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Subject.Part2();
            Assert.Equal(12, result);
        }
    }
}
