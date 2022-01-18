namespace bbv.Examples.SOLID._2_OCP.II_Solution
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