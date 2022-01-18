// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    public class Book : Item
    {
        public Book(int id, string title, Price price, string author)
            : base(id, title, price)
        {
            this.Author = author;
        }

        public string Author { get; }

        public override string GetString()
        {
            return $"Book: {this.Title} by {this.Author}\t> {this.Price}";
        }
    }
}