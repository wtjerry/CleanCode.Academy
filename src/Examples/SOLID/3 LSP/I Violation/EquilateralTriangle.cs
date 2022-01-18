namespace bbv.Examples.SOLID._3_LSP.I_Violation
{
    using System;

    public class EquilateralTriangle : Triangle
    {
        public override double LengthA
        {
            get
            {
                return base.LengthA;
            }

            set
            {
                base.LengthA = value;
                base.LengthB = value;
                base.LengthC = value;
            }
        }

        public override double GetArea()
        {
            double a = this.LengthA;

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