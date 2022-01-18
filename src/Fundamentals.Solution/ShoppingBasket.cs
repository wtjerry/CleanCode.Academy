namespace Fundamentals.Solution
{
    using System.Collections.Generic;

    internal class ShoppingBasket
    {
        private readonly List<OrderItem> orderItems;

        public ShoppingBasket(string customerName)
        {
            this.CustomerName = customerName;
            this.orderItems = new List<OrderItem>();
        }

        public string CustomerName { get; }

        public void Add(OrderItem item)
        {
            this.orderItems.Add(item);
        }

        // ReSharper disable once ReturnTypeCanBeEnumerable.Global
        public IReadOnlyList<OrderItem> GetAllItems()
        {
            return this.orderItems.ToArray();
        }
    }
}