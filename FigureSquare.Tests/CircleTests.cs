using Xunit;
using FigureSquare.Modules;

namespace FigureSquare.Tests
{
    public class CircleTests
    {
        [Fact]
        public void GetArea_WithRadius5_ReturnsCorrectArea()
        {
            var circle = new CircleForTest(5);
            double expected = Math.PI * 25;
            Assert.Equal(expected, circle.GetArea(), 5);
        }

        private class CircleForTest : Circle
        {
            public CircleForTest(double radius)
            {
                typeof(Circle)
                    .GetProperty("Radius", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                    .SetValue(this, radius);
            }
        }
    }
}
