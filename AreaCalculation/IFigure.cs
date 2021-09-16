using System;

namespace AreaCalculation
{
    public interface IFigure
    {
        public double figureArea();
    }

    public class Circle : IFigure
    {
        private double radius;
        public Circle(double radius) => this.radius = radius>0 ? radius : throw new ArgumentException();
        public double figureArea()
        {
            double result = Math.PI * Math.Pow(radius, 2);
            return result;
        }
    }

    public class Triangle : IFigure
    {
        private double sideA;
        private double sideB;
        private double sideC;
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA * sideB * sideC <= 0)
                throw new ArgumentException();
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }
        public bool IsRectangular
        {
            get 
            {
                var aSqr = sideA * sideA;
                var bSqr = sideB * sideB;
                var cSqr = sideC * sideC;
                return (aSqr + bSqr == cSqr) || (aSqr + cSqr == bSqr) || (bSqr + cSqr == aSqr);
            }
        }
        public double figureArea()
        {
            double result;
            double halfPerimeter = (sideA + sideB + sideC) / 2;
            result = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
            return result;
        }
    }

}
