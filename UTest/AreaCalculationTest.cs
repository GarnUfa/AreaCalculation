using System;
using Xunit;
using AreaCalculation;

namespace UTest
{
    public class AreaCalculationTest
    {
        [Theory]
        [InlineData(-10)]
        [InlineData(-10.25)]
        [InlineData(0)]
        [InlineData(double.MinValue)]
        public void Circle_NegativeValue_ExceptionReturn(double value)
        {
            Assert.Throws<ArgumentException>(delegate()
            {
                new Circle(value);
            });
        }
        [Theory]
        [InlineData(10)]
        [InlineData(1.2524524524)]
        [InlineData(double.MaxValue)]
        [InlineData(int.MaxValue)]
        public void CircleFigureArea_PositiveValue_Equal(double value)
        {
            double expected = Math.PI * Math.Pow(value, 2);
            Circle circle = new Circle(value);
            double actual = circle.figureArea();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-10, 10, 10)]
        [InlineData(-10.25, 10, 10)]
        [InlineData(0, 10, 10)]
        [InlineData(double.MinValue, 10, 10)]
        public void Triangle_NegativeValue_ExceptionReturn(double value, double value2, double value3)
        {
            Assert.Throws<ArgumentException>(delegate ()
            {
                new Triangle(value, value2, value3);
            });
        }

        [Theory]
        [InlineData(10, 10, 10)]
        [InlineData(10.25, 10, 10)]
        [InlineData(18, 10, 10)]
        [InlineData(double.MaxValue, 10, 10)]
        public void TriangleFigureArea_PositiveValue_Equal(double value, double value2, double value3)
        {
            double halfPerimeter = (value+value2+value3)/2;
            double expected = Math.Sqrt(halfPerimeter * (halfPerimeter - value) * (halfPerimeter - value2) * (halfPerimeter - value3));
            Triangle triangle = new Triangle(value, value2, value3);
            double actual = triangle.figureArea();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 10, 10)]
        [InlineData(10.25, 10, 10)]
        [InlineData(18, 10, 10)]
        [InlineData(double.MaxValue, 10, 10)]
        public void TriangleIsRectangular_PositiveValue_False(double value, double value2, double value3)
        {
            Triangle triangle = new Triangle(value, value2, value3);
            Assert.False(triangle.IsRectangular);
        }

        [Theory]
        [InlineData(10.5, 10, 14.5)]
        public void TriangleIsRectangular_PositiveValue_True(double value, double value2, double value3)
        {
            Triangle triangle = new Triangle(value, value2, value3);
            Assert.True(triangle.IsRectangular);
        }

        [Theory]
        [InlineData(10.5, 10, 14.5)]
        [InlineData(10.25, 10, 10)]
        [InlineData(18, 10, 10)]
        [InlineData(double.MaxValue, 10, 10)]
        public void TriangleIsRectangular_PositiveValue_Equal(double value, double value2, double value3)
        {
            var aSqr = value * value;
            var bSqr = value2 * value2;
            var cSqr = value3 * value3;
            bool expected = (aSqr + bSqr == cSqr) || (aSqr + cSqr == bSqr) || (bSqr + cSqr == aSqr);
            Triangle triangle = new Triangle(value, value2, value3);
            bool actual = triangle.IsRectangular;
            Assert.Equal(expected, actual);
        }

    }
}
