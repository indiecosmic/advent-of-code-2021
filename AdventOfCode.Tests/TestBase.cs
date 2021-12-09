using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests
{
    public abstract class TestBase<T, TU>
    {
        protected T Subject { get; }

        public TestBase(TU input)
        {
            Subject = (T)Activator.CreateInstance(typeof(T), input);
        }
    }
}
