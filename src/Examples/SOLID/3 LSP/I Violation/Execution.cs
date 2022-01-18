namespace bbv.Examples.SOLID._3_LSP.I_Violation
{
    using System;

    public static class Execution
    {
        public static void Run()
        {
            Console.WriteLine("LSP Violation Example");

            var triangles = new[]
            {
                new Triangle { LengthA = 4, LengthB = 13, LengthC = 15 },
                new EquilateralTriangle { LengthA = 3 }
            };

            var calculator = new AreaCalculator(triangles);
            Console.WriteLine("Sum of the areas provided: {0}", calculator.Sum());
        }
    }
}
