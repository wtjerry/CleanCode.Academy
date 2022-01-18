namespace Fundamentals.Solution
{
    using System.Collections.ObjectModel;

    internal class ShoppingBasketCollection : KeyedCollection<string, ShoppingBasket>
    {
        protected override string GetKeyForItem(ShoppingBasket item)
        {
            return item.CustomerName;
        }
    }
}