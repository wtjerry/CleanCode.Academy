namespace bbv.Examples.SOLID._2_OCP.II_Solution
{
    using System.Linq;

    public class AreaCalculator
    {
        private readonly IShape[] shapes;

        public AreaCalculator(IShape[] shapes)
        {
            this.shapes = shapes;
        }

        public double Sum()
        {
            return this.shapes.Sum(shape => shape.GetArea());
        }
    }
}