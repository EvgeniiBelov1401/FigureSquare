using FigureSquare.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FigureSquare.Tests
{
    public class TriangleTests
    {
        [Fact]
        public void Triangle_WithValidSides_ReturnsCorrectArea()
        {
            var triangle = new TriangleForTest(3, 4, 5);
            double expected = 6.0;
            double actual = triangle.GetArea();
            Assert.Equal(expected, actual, 5);
        }

        [Fact]
        public void Triangle_WithValidSides_IsRightAngled()
        {
            var triangle = new TriangleForTest(3, 4, 5);
            Assert.True(triangle.Exist);
            Assert.Equal("Прямоугольный треугольник", triangle.Type);
        }

        [Fact]
        public void Triangle_WithInvalidSides_DoesNotExist()
        {
            var triangle = new TriangleForTest(1, 2, 10);
            Assert.False(triangle.Exist);
        }

        [Fact]
        public void Triangle_WithEquilateralSides_IsNotRightAngled()
        {
            var triangle = new TriangleForTest(5, 5, 5);
            Assert.True(triangle.Exist);
            Assert.Equal("Непрямоугольный треугольник", triangle.Type);
        }

        private class TriangleForTest : Triangle
        {
            public TriangleForTest(double a, double b, double c)
            {
                typeof(Triangle).GetProperty("Side1", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                    .SetValue(this, a);
                typeof(Triangle).GetProperty("Side2", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                    .SetValue(this, b);
                typeof(Triangle).GetProperty("Side3", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                    .SetValue(this, c);

                typeof(Triangle).GetMethod("CheckTriangle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                    .Invoke(this, null);
            }
        }
    }
}
