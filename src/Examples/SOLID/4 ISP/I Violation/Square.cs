namespace bbv.Examples.SOLID._4_ISP.I_Violation
{
    public class Square : IShape
    {
        private readonly double length;

        public Square(double length)
        {
            this.length = length;
        }

        public double GetArea()
        {
            return this.length * this.length;
        }

        public double GetVolume()
        {
            return 0;
        }
    }
}