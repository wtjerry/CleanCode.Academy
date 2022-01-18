namespace bbv.Examples.SOLID._2_OCP.II_Solution
{
    using System;

    public static class Execution
    {
        public static void Run()
        {
            Console.WriteLine("OCP Solution Example");

            var shapes = new IShape[]
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
