using Xunit;

namespace AdventOfCode.Tests
{
    public class Day07_Tests
    {
        private const string Input = "16,1,2,0,4,2,7,1,2,14";
        private Day07 Subject => new(Input);

        [Fact]
        public void Part1()
        {
            var result = Subject.Part1();
            Assert.Equal(37, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Subject.Part2();
            Assert.Equal(168, result);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 6)]
        [InlineData(4, 10)]
        [InlineData(5, 15)]
        public void FuelCost(int distance, int expected)
        {
            Assert.Equal(expected, Subject.FuelCost(distance));
        }
    }
}
