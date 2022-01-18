namespace bbv.Examples.SOLID._4_ISP.I_Violation
{
    public class Cube : IShape
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