namespace bbv.Examples.SOLID._4_ISP.II_Solution
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
    }
}