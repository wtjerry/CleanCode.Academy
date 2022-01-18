namespace bbv.Examples.SOLID._1_SRP.II_Solution
{
    using System;

    public class AreaCalculator
    {
        private readonly object[] shapes;

        public AreaCalculator(object[] shapes)
        {
            this.shapes = shapes;
        }

        public double Sum()
        {
            double result = 0;

            foreach (var shape in this.shapes)
            {
                if (shape is Circle)
                {
                    var circle = (Circle)shape;
                    result += circle.Radius * circle.Radius * Math.PI;
                }
                else if (shape is Square)
                {
                    var square = (Square)shape;
                    result += square.Length * square.Length;
                }
                else
                {
                    throw new InvalidOperationException("Unknown shape type for " + shape);
                }
            }

            return result;
        }
    }
}