namespace bbv.Examples.SOLID._2_OCP.I_Violation
{
    using System;

    public static class Execution
    {
        public static void Run()
        {
            Console.WriteLine("OCP Violation Example");

            var shapes = new object[]
            {
                new Circle(2),
                new Square(5),
                new Square(6),
                new EquilateralTriangle(4)
            };

            var calculator = new AreaCalculator(shapes);
            Console.WriteLine("Sum of the areas provided: {0}", calculator.Sum());
        }
    }
}
