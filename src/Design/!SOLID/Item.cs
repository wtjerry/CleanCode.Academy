// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidExercise
{
    using System;

    public abstract class Item
    {
        protected Item(int id, string title, decimal priceInChf, ItemType type)
        {
            this.Id = id;
            this.Title = title;
            this.PriceInChf = priceInChf;
            this.Type = type;
            this.Color = ItemColor.Blue; // blue is the default color
        }

        public int Id { get; }
        public string Title { get; }
        public decimal PriceInChf { get; }
        public ItemType Type { get; }
        public ItemColor Color { get; private set; }

        public void ChangeColor(ItemColor newColor)
        {
            if (this.Type == ItemType.Book)
            {
                throw new InvalidOperationException("The colors of a book can not be changed.");
            }

            if (this.Type != ItemType.Notebook && newColor == ItemColor.Yellow)
            {
                throw new ArgumentException("Yellow can only be applied to notebooks");
            }

            this.Color = newColor;
        }

        /// <summary>
        /// Returns the string representation of the order item.
        /// </summary>
        public virtual string GetString()
        {
            return $"{this.Type}: {this.Title} in {this.Color}\t> {this.PriceInChf} CHF";
        }

        /// <summary>
        /// Calculates the price in euro.
        /// </summary>
        public decimal GetPriceInEuro()
        {
            return this.PriceInChf * 0.9120m;
        }
    }

    public class Book : Item
    {
        public Book(int id, string title, decimal priceInChf, string author)
            : base(id, title, priceInChf, ItemType.Book)
        {
            this.Author = author;
        }

        public string Author { get; }

        public override string GetString()
        {
            return $"{this.Type}: {this.Title} by {this.Author}\t> {this.PriceInChf} CHF";
        }
    }

    public class Notebook : Item
    {
        public Notebook(int id, string title, decimal priceInChf)
            : base(id, title, priceInChf, ItemType.Notebook)
        {
        }
    }

    public class Pen : Item
    {
        public Pen(int id, string title, decimal priceInChf)
            : base(id, title, priceInChf, ItemType.Pen)
        {
        }
    }
}