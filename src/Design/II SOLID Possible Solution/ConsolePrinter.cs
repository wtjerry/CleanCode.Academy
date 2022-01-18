// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ConsolePrinter
    {
        public static void PrintToConsole(IReadOnlyCollection<Item> items)
        {
            var total = Price.FromChf(items.Sum(i => i.Price.InChf));

            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    items.Select(i => i.GetString())));

            Console.WriteLine($"Total: {total}");
        }
    }
}