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
        public void CreateMap()
        {
            var input = new[]
            {
                "8"
            };

            var expected = new[]
            {
                "89123",
                "91234",
                "12345",
                "23456",
                "34567"
            };

            var map = Util.To2DIntArray(input);
            var result = Day15.CreateBigMap(map, 5);
            var actual = Util.ToStringArray(result);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateMap2()
        {
            var input = new[]
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
            };

            var expected = new[]
            {
                "11637517422274862853",
                "13813736722492484783",
                "21365113283247622439",
                "36949315694715142671",
                "74634171118574528222",
                "13191281372421239248",
                "13599124212461123532",
                "31254216394236532741",
                "12931385212314249632",
                "23119445813422155692",
                "22748628533385973964",
                "24924847833513595894",
                "32476224394358733541",
                "47151426715826253782",
                "85745282229685639333",
                "24212392483532341359",
                "24611235323572234643",
                "42365327415347643852",
                "23142496323425351743",
                "34221556924533266713",
            };

            var map = Util.To2DIntArray(input);
            var result = Day15.CreateBigMap(map, 2);
            var actual = Util.ToStringArray(result);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part1()
        {
            var result = Subject.Part1();
            Assert.Equal(40, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Subject.Part2();
            Assert.Equal(315, result);
        }

    }
}
