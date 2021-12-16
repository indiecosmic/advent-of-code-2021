using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Util_Tests
    {
        [Fact]
        public void Conversions()
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
            var result = Util.To2DIntArray(input);
            var str = Util.ToStringArray(result);
            Assert.Equal(input, str);
        }
    }
}
