namespace Fundamentals.Solution
{
    using System.Linq;

    public class ShoppingBasketPriceCalculator
    {
        private readonly ShoppingBasketCollection shoppingBaskets = new ShoppingBasketCollection();

        /// <summary>
        /// Creates a new shopping basket for customer <paramref name="customerName"/>.
        /// </summary>
        public void CreateFor(string customerName)
        {
            if (this.BasketForCustomerExists(customerName))
            {
                return;
            }

            this.shoppingBaskets.Add(new ShoppingBasket(customerName));
        }

        /// <summary>
        /// Adds the <paramref name="orderItem"/> to the shopping basket of customer <paramref name="customerName"/>.
        /// </summary>
        public void AddItem(string customerName, OrderItem orderItem)
        {
            this.shoppingBaskets[customerName].Add(orderItem);
        }

        /// <summary>
        /// Calculates the price of all items in the shopping basket of customer <paramref name="customerName"/>.
        /// </summary>
        /// <returns>
        /// The total price of all items ordered by customer.
        /// </returns>
        public decimal GetTotalPriceOfOrder(string customerName)
        {
            return this.shoppingBaskets[customerName]
                .GetAllItems()
                .Sum(orderItem => orderItem.Price);
        }

        private bool BasketForCustomerExists(string customerName)
        {
            return this.shoppingBaskets.Contains(customerName);
        }
    }
}
