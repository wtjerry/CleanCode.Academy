namespace bbv.Examples.SOLID._2_OCP.II_Solution
{
    using System;

    public class Circle : IShape
    {
        private readonly double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetArea()
        {
            return this.radius * this.radius * Math.PI;
        }
    }
}