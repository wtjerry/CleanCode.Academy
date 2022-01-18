namespace bbv.Examples.SOLID._1_SRP.II_Solution
{
    using System;

    public static class Execution
    {
        public static void Run()
        {
            Console.WriteLine("SRP possible Solution Example");

            var shapes = new object[]
            {
                new Circle(2),
                new Square(5),
                new Square(6)
            };

            var calculator = new AreaCalculator(shapes);
            var output = new OutputFormatter();

            var sum = calculator.Sum();
            output.ToSimpleString(sum);
            output.ToJsonString(sum);
            output.ToHtmlString(sum);
        }
    }
}
