using Xunit;
using FigureSquare.Modules;

namespace FigureSquare.Tests
{
    public class TriangleTests
    {
        [Fact]
        public void Triangle_WithValidSides_ReturnsCorrectArea()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.True(triangle.Exist);
            double expected = 6.0;
            Assert.Equal(expected, triangle.GetArea(), 5);
        }

        [Fact]
        public void Triangle_WithValidSides_IsRightAngled()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.True(triangle.Exist);
            Assert.Equal("Прямоугольный треугольник", triangle.Type);
        }

        [Fact]
        public void Triangle_WithInvalidSides_DoesNotExist()
        {
            var triangle = new Triangle(1, 2, 10);
            Assert.False(triangle.Exist);
        }

        [Fact]
        public void Triangle_WithEquilateralSides_IsNotRightAngled()
        {
            var triangle = new Triangle(5, 5, 5);
            Assert.True(triangle.Exist);
            Assert.Equal("Непрямоугольный треугольник", triangle.Type);
        }

        [Fact]
        public void Constructor_WithZeroOrNegativeSide_Throws()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(0, 1, 1));
            Assert.Throws<ArgumentException>(() => new Triangle(-1, 2, 2));
        }
    }
}