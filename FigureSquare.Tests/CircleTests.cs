using Xunit;
using FigureSquare.Modules;
using System;

namespace FigureSquare.Tests
{
    public class CircleTests
    {
        [Fact]
        public void GetArea_WithRadius5_ReturnsCorrectArea()
        {
            var circle = new Circle(5);
            double expected = Math.PI * 25;
            Assert.Equal(expected, circle.GetArea(), 5);
        }

        [Theory]
        [InlineData(1, Math.PI)]
        [InlineData(2, 4 * Math.PI)]
        [InlineData(0.5, 0.25 * Math.PI)]
        public void GetArea_WithVariousRadii_ReturnsExpectedArea(double radius, double expected)
        {
            var circle = new Circle(radius);
            Assert.Equal(expected, circle.GetArea(), 5);
        }

        [Fact]
        public void Constructor_WithZeroOrNegativeRadius_Throws()
        {
            Assert.Throws<ArgumentException>(() => new Circle(0));
            Assert.Throws<ArgumentException>(() => new Circle(-1));
        }
    }
}
