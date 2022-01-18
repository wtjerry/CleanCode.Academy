namespace bbv.Examples.SOLID._1_SRP.I_Violation
{
    using System;

    public static class Execution
    {
        public static void Run()
        {
            Console.WriteLine("SRP Violation Example");

            var shapes = new object[]
            {
                new Circle(2),
                new Square(5),
                new Square(6)
            };

            var calculator = new AreaCalculator(shapes);
            calculator.WriteToConsole();
        }
    }
}
