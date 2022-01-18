namespace bbv.Examples.SOLID._1_SRP.I_Violation
{
    public class Circle
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }
    }
}