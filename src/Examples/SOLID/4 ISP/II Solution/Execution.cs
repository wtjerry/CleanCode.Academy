namespace bbv.Examples.SOLID._4_ISP.II_Solution
{
    using System;

    public static class Execution
    {
        public static void Run()
        {
            Console.WriteLine("ISP Violation Example");

            IShape square = new Square(5);
            Console.WriteLine("The area of the square is: {0}", square.GetArea());

            var cube = new Cube(5);
            Console.WriteLine("The area of the cube is: {0}", cube.GetArea());
            Console.WriteLine("The volume of the cube is: {0}", cube.GetVolume());
        }
    }
}
