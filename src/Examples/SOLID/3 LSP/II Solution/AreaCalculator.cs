namespace bbv.Examples.SOLID._3_LSP.II_Solution
{
    using System.Linq;

    public class AreaCalculator
    {
        private readonly Shape[] shapes;

        public AreaCalculator(Shape[] shapes)
        {
            this.shapes = shapes;
        }

        public double Sum()
        {
            return this.shapes.Sum(t => t.GetArea());
        }
    }
}