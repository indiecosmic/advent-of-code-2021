using Xunit;

namespace AdventOfCode.Tests
{
    public class Day11_Tests : TestBase<Day11, string[]>
    {
        public Day11_Tests()
        : base(new[]
        {
            "5483143223", 
            "2745854711",
            "5264556173",
            "6141336146",
            "6357385478",
            "4167524645",
            "2176841721",
            "6882881134",
            "4846848554",
            "5283751526"
        })
        {
        }

        [Fact]
        public void Part1()
        {
            var result = Subject.Part1();
            Assert.Equal(1656, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Subject.Part2();
            Assert.Equal(195, result);
        }
    }
}
