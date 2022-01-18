// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    using System.Collections.Generic;

    public class ShoppingBasket
    {
        private readonly List<Item> itemsInBasket = new List<Item>();

        public void Add(Item item)
        {
            this.itemsInBasket.Add(item);
        }

        public IReadOnlyList<Item> Items => this.itemsInBasket;
    }
}