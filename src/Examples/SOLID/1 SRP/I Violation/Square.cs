namespace bbv.Examples.SOLID._1_SRP.I_Violation
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