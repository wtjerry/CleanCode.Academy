// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    public abstract class Item
    {
        protected Item(int id, string title, Price price)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
        }

        public int Id { get; }

        public string Title { get; }

        public Price Price { get; }

        /// <summary>
        /// Returns the string representation of the order item.
        /// </summary>
        public abstract string GetString();
    }
}
