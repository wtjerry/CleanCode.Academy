// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    public class Notebook : Item
    {
        public Notebook(int id, string title, Price price, NotebookColor color)
            : base(id, title, price)
        {
            this.Color = color;
        }

        public NotebookColor Color { get; }

        public override string GetString()
        {
            return $"Notebook: {this.Title} in {this.Color}\t> {this.Price}";
        }
    }
}