using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day11_Tests_Simple : TestBase<Day11, string[]>
    {
        public Day11_Tests_Simple()
        : base(new []
        {
            "11111",
            "19991",
            "19191",
            "19991",
            "11111"
        })
        {
        }

        [Fact]
        public void Tick()
        {
            Subject.Tick();

            var expectedTick1 = new[]
            {
                "34543",
                "40004",
                "50005",
                "40004",
                "34543"
            };
            Assert.Equal(expectedTick1, Subject.Output);

            Subject.Tick();
            var expectedTick2 = new[]
            {
                "45654",
                "51115",
                "61116",
                "51115",
                "45654"
            };
            Assert.Equal(expectedTick2, Subject.Output);
        }
    }
}
