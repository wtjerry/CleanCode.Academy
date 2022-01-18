namespace Fundamentals
{
    using System;

    /// <summary>
    /// Represents a sample call execution for the given classes.
    /// </summary>
    /// <remarks>
    /// Obviously, there are some design issues with this solution. But the main focus of this example lies in
    /// the formatting and code analysis features, rather than good class design. We will address good class design
    /// at a later time.
    /// </remarks>
    public class Program
    {
        public void Main()
        {
            const string CustomerName = "Max Muster";

            var bookItem = new OrderItem
            {
                Id = 1, Title = "Clean Code", Type = ItemType.Book, Price = 43.9m
            };

            var otherItem = new OrderItem
            {
                Id = 2, Title = "Notebook", Type = ItemType.Other, Price = 5m
            };

            var manager = new OrderManager();
            manager.CreateNewOrder(CustomerName);
            manager.AddItemToOrder(CustomerName, bookItem);
            manager.AddItemToOrder(CustomerName, otherItem);
            var totalPrice = manager.GetTotalPriceOfOrder(CustomerName);

            Console.WriteLine($"The total price is: {totalPrice}");
        }
    }
}
