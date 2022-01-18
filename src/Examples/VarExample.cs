namespace bbv.Examples
{
    using System;

    /// <summary>
    /// In this class some variables will be declared using the `var` statement.
    /// Modern IDEs should show the type of the variable right next to its name.
    /// </summary>
    public static class VarExample
    {
        public static void Values()
        {
            var number = 2;
            var text = "1.2";
            var doubleNumber = 2.1d;

            var first = 1 + number;
            var second = 2.2f + doubleNumber;
            var third = Convert.ToDecimal(text) + 2;

            Console.WriteLine($"The values are `{first}`," +
                              $"`{second}` and `{third}`");
        }
    }
}