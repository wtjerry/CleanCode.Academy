namespace bbv.Examples.SOLID._3_LSP.I_Violation
{
    using System;

    public class Triangle
    {
        public virtual double LengthA { get; set; }

        public virtual double LengthB { get; set; }

        public virtual double LengthC { get; set; }

        public virtual double GetArea()
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