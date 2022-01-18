namespace bbv.Examples.SOLID._2_OCP.I_Violation
{
    public class EquilateralTriangle
    {
        public EquilateralTriangle(double length)
        {
            this.Length = length;
        }

        public double Length { get; private set; }
    }
}