namespace bbv.Examples.SOLID._3_LSP.II_Solution
{
    using System;

    public class EquilateralTriangle : Shape
    {
        public double Length { get; set; }

        public override double GetArea()
        {
            double a = this.Length;

            // Trignonometry formula
            //       _
            //      √3
            // h = ———— a
            //       2
            //
            //       h²
            // A =  ————
            //       √3
            //
            double h = Math.Sqrt(3) / 2 * a;
            double area = h * h / Math.Sqrt(3);

            return area;
        }
    }
}