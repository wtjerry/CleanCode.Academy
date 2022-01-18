namespace bbv.Examples.SOLID._3_LSP.I_Violation
{
    using System.Linq;

    public class AreaCalculator
    {
        private readonly Triangle[] triangles;

        public AreaCalculator(Triangle[] triangles)
        {
            this.triangles = triangles;
        }

        public double Sum()
        {
            return this.triangles.Sum(t => t.GetArea());
        }
    }
}