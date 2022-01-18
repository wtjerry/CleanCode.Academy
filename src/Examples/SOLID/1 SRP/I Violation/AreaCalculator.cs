namespace bbv.Examples.SOLID._1_SRP.I_Violation
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

        public void WriteToConsole()
        {
            Console.WriteLine("Sum of the areas provided: {0}", this.Sum());
        }
    }
}