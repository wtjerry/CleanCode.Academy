namespace bbv.Examples.SOLID._4_ISP.II_Solution
{
    public class Cube : IShape, ISolidShape
    {
        private readonly double length;

        public Cube(double length)
        {
            this.length = length;
        }

        public double GetArea()
        {
            //      .———.
            //      | a²|
            //  .———|———|———.———.
            //  | a²| a²| a²| a²|
            //  '———|———|———'———'
            //      | a²|
            //      '———'
            return this.length * this.length * 6;
        }

        public double GetVolume()
        {
            return this.length * this.length * this.length;
        }
    }
}