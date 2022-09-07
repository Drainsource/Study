using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BasicMath.Test
{
  
    public class BasicMathOperationsTest
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 2)]
        [InlineData(2, 1, 3)]
        [InlineData(2, 3, 5)]
        public void AddTest(
            double x,
            double y,
            double expected)
        {
            BasicMathOperations math = new BasicMathOperations();
            var actual = math.Add(x, y);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(2, 1, 1)]
        [InlineData(2, 3, -1)]
        public void SubTest(
        double x,
        double y,
        double expected)
        {
            BasicMathOperations math = new BasicMathOperations();
            var actual = math.Sub(x, y);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(2, 1, 2)]
        [InlineData(2, 3, 6)]
        public void MultpleTest(
        double x,
        double y,
        double expected)
        {
            BasicMathOperations math = new BasicMathOperations();
            var actual = math.Multiple(x, y);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(2, 1, 2)]
        [InlineData(2, 4, 0.5)]
        public void DivideTest(
        double x,
        double y,
        double expected)
        {
            BasicMathOperations math = new BasicMathOperations();
            if (y == 0)
            {
                Assert.Throws<DivideByZeroException>(() => math.Divide(x, y));
            }
            else
            {
                var actual = math.Divide(x, y);
                Assert.Equal(expected, actual);
            }
            
        }


    }
}
