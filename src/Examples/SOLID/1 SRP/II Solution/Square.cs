namespace bbv.Examples.SOLID._1_SRP.II_Solution
{
    public class Square
    {
        public Square(double length)
        {
            this.Length = length;
        }

        public double Length { get; private set; }
    }
}