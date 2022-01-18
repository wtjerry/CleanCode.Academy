namespace bbv.Examples.SOLID._3_LSP.II_Solution
{
    using System;

    public static class Execution
    {
        public static void Run()
        {
            Console.WriteLine("LSP Solution Example");

            var triangles = new Shape[]
            {
                new RegularTriangle { LengthA = 4, LengthB = 13, LengthC = 15 },
                new EquilateralTriangle { Length = 3 }
            };

            var calculator = new AreaCalculator(triangles);
            Console.WriteLine("Sum of the areas provided: {0}", calculator.Sum());
        }
    }
}
