namespace bbv.Examples.SOLID._2_OCP.II_Solution
{
    using System;

    public class EquilateralTriangle : IShape
    {
        private readonly double length;

        public EquilateralTriangle(double length)
        {
            this.length = length;
        }

        public double GetArea()
        {
            return this.length * this.length * Math.Sqrt(3) / 4;
        }
    }
}