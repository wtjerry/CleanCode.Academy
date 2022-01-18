namespace bbv.Examples.SOLID._3_LSP.II_Solution
{
    using System;

    public class RegularTriangle : Shape
    {
        public double LengthA { get; set; }

        public double LengthB { get; set; }

        public double LengthC { get; set; }

        public override double GetArea()
        {
            double a = this.LengthA;
            double b = this.LengthB;
            double c = this.LengthC;

            // Trignonometry formula
            //
            //      a + b + c
            // s =  —————————
            //          2
            //      ________________
            // A = √s(s-a)(s-b)(s-c)
            //
            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }
    }
}