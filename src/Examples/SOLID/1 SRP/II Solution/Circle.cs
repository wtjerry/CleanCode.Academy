namespace bbv.Examples.SOLID._1_SRP.II_Solution
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